
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Persistence;
using JeSuisCatho.Web.API.Controllers.Resources;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace JeSuisCatho.Web.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly JeSuisCathoDbContext context;


        public ProductsController(JeSuisCathoDbContext context, IMapper mapper, IProductRepository repository, IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.photoRepository = photoRepository;
            this.unitOfWork = unitOfWork;
            this.context = context;

        }





        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductResource productResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);




            var product = mapper.Map<SaveProductResource, Product>(productResource);
            product.LastUpdate = DateTime.Now;

            repository.Add(product);
            await unitOfWork.CompleteAsync();



            product = await repository.GetProduct(product.Id);

            var result = mapper.Map<Product, ProductResource>(product);
            return Ok(result);
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] SaveProductResource productResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.GetProduct(id);

            if (product == null)
                return NotFound();

            mapper.Map<SaveProductResource, Product>(productResource, product);
            product.LastUpdate = DateTime.Now;

            // context.Articles.Add(article);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Product, ProductResource>(product);
            return Ok(result);
        }



        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repository.GetProduct(id, includeRelated: false);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await repository.GetProduct(id);


            if (product == null)
                return NotFound();

            var productResource = mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpGet("productOfSeason")]
        public async Task<IActionResult> GetProductBySeason(bool productOfSeason)
        {
            var product = await repository.GetProductBySeason(productOfSeason);

            if (product == null)
                return NotFound();

            var productResource = mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetProducts()
        { 

       
            var products = await context.Products
                .Include(p => p.SubCategoryItem)
                    .ThenInclude(s => s.CategoryItem)
                .Include(s => s.Suppliers)
                    .ThenInclude(ps => ps.Supplier)
               .Include(p => p.Photos).Where(photo => photo.Id == photo.Id)
                .ToListAsync();

          

            return mapper.Map<List<Product>, List<ProductResource>>(products);

        }

        [HttpGet("photos")]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int productId)
        {
            var photos = await photoRepository.GetPhotos(productId);

            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }




    }
}
