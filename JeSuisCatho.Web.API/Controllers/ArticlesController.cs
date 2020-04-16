using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Persistence;
using JeSuisCatho.Web.API.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;





namespace JeSuisCatho.Web.API.Controllers
{
    [Route("/api/articles")]
 
    [ApiController]
    [Authorize]
    public class ArticlesController : Controller
    {

     
       private readonly IMapper mapper;
       private readonly IArticleRepository repository;
        private readonly IUnitOfWork unitOfWork;
         private readonly JeSuisCathoDbContext context;
       public ArticlesController(JeSuisCathoDbContext context, IMapper mapper, IArticleRepository repository, IUnitOfWork unitOfWork)
       {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.context = context; 

       }


           [HttpPost]
          // [Authorize]
        public async Task<IActionResult> CreateArticle([FromBody] SaveArticleResource articleResource) 
           {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);




            var article = mapper.Map<SaveArticleResource, Article>(articleResource);
            article.LastUpdate = DateTime.Now;

            repository.Add(article);
            await unitOfWork.CompleteAsync();



            article = await repository.GetArticle(article.Id);

            var result = mapper.Map<Article, ArticleResource>(article);
           return Ok(result);
           }


        [HttpPut("{id}")]
      //  [Authorize]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] SaveArticleResource articleResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var article = await repository.GetArticle(id);

            if (article == null)
                return NotFound();

            mapper.Map<SaveArticleResource, Article>(articleResource, article);
            article.LastUpdate = DateTime.Now;

            // context.Articles.Add(article);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Article, ArticleResource>(article);
            return Ok(result);
        }



       [HttpDelete("{id}")]
      //  [Authorize]
        public async  Task<IActionResult> DeleteArticle(int id)
        {
            var article = await repository.GetArticle(id, includeRelated: false);


            if (article == null)
                return NotFound();


            repository.Remove(article);
            await unitOfWork.CompleteAsync();


            return Ok(id);
        }

        [HttpGet("{id}")]
       // [Authorize]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await repository.GetArticle(id);


            if (article == null)
                return NotFound();

            var articleResource = mapper.Map<Article, ArticleResource>(article);

           return Ok(articleResource);
        }

        [HttpGet]

        public async Task<IEnumerable<ArticleResource>> GetArticles()
        {
            var articles = await context.Articles
                .Include(a => a.NewsCategory)
                    .ThenInclude(n => n.NewsEvent)  
                .Include(l =>l.Locations)
                    .ThenInclude(al => al.Location)
                .ToListAsync();

            return mapper.Map<List<Article>, List<ArticleResource>>(articles);

        }






    }
}
