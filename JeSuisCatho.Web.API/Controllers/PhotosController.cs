using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models.Shop;


namespace Veewd.Controllers
{
    [Route("/api/products/{productId}/photos")]
  
    public class PhotosController : Controller
    {

       
        private readonly IHostingEnvironment host;
        private readonly IProductRepository productRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IMapper mapper;
       private readonly IUnitOfWork unitOfWork;
        private readonly PhotoSettings photoSettings;
        private readonly IPhotoService photoService;
        public PhotosController(IHostingEnvironment host, IProductRepository productRepository, 
           IMapper mapper, IUnitOfWork unitOfWork, IPhotoService photoService, IOptionsSnapshot<PhotoSettings> options,
            IPhotoRepository photoRepository)
        {
            this.photoSettings = options.Value;
            this.host = host;
            this.productRepository = productRepository;
            this.photoRepository = photoRepository;
            this.unitOfWork = unitOfWork;
            this.photoService = photoService;
            this.mapper = mapper;
        }

   


        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int productId)
        {
            var photos = await photoRepository.GetPhotos(productId);

            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int productId, IFormFile file)
        {
            var product = await productRepository.GetProduct(productId, includeRelated: false);

            if (product == null)
                return NotFound();


            if (file == null) return BadRequest("Null Photo File");
            if (file.Length == 0) return BadRequest("Empty Photo File");
            if (file.Length > photoSettings.MaxBytes) return BadRequest("Maximum file size exceeded");
            if (!photoSettings.IsSupported(file.FileName)) return BadRequest("File type is invalid");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "photoUploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

          var filePath =  Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
               await file.CopyToAsync(stream);
            }

            var photo = new Photo { PhotoFileName = fileName };
            product.Photos.Add(photo);
           await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Photo, PhotoResource>(photo));
        }
    }
}
