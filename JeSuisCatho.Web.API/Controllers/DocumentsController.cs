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
using JeSuisCatho.Web.API.Controllers.Resources;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Controllers
{
    [Route("/api/documents")]
    public class DocumentsController : Controller
    {
       
        private readonly IHostingEnvironment host;
      //  private readonly IPosterRepository posterRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly DocumentSettings documentSettings;
        private readonly IDocumentService documentService;
        public DocumentsController(IHostingEnvironment host, 
            IUnitOfWork unitOfWork, IMapper mapper, IDocumentService documentService, IOptionsSnapshot<DocumentSettings> options,
            IDocumentRepository documentRepository)
        {
            this.documentSettings = options.Value;
            this.host = host;
         //   this.posterRepository = posterRepository;
            this.documentRepository = documentRepository;
            this.unitOfWork = unitOfWork;
            this.documentService = documentService;
            this.mapper = mapper;
        }


    

        [HttpGet]
        public async Task<IEnumerable<DocumentResource>> GetDocuments()
        {
            var documents = await documentRepository.GetDocuments();

            return mapper.Map<IEnumerable<Document>, IEnumerable<DocumentResource>>(documents);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(string englishDesc, string frenchDesc, IFormFile file)
        {
            var documentUpload = await documentRepository.GetDocuments();
          // var doc = await 

         //   i//f (poster == null)
              //  return NotFound();

            if (file == null) return BadRequest("Null Document File");
            if (file.Length == 0) return BadRequest("Empty Document File");
            if (file.Length > documentSettings.MaxBytes) return BadRequest("Maximum file size exceeded");
            if (!documentSettings.IsSupported(file.FileName)) return BadRequest("File type is invalid");


            var uploadsFolderPath = Path.Combine(host.WebRootPath, "documentUploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new Document { DocumentFileName = fileName, EnglishDesc = englishDesc, FrenchDesc = frenchDesc };
            //  context.Documents.Add(document);
            // context.Documents.Add(document);
            documentRepository.Add(document);
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Document, DocumentResource>(document));
        }
    }
}
