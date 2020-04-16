using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Persistence
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly JeSuisCathoDbContext context;
        public ArticleRepository(JeSuisCathoDbContext context)
        {
            this.context = context;
        }

        public async Task<Article> GetArticle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Articles.FindAsync(id);

            return await context.Articles
             .Include(a => a.Locations)
                 .ThenInclude(al => al.Location)
             .Include(a => a.NewsCategory)
                  .ThenInclude(n => n.NewsEvent)
              .SingleOrDefaultAsync(a => a.Id == id);

        }


       public void Add(Article article)
       {
                context.Articles.Add(article);
        
       }

       public void Remove(Article article)
       {
                context.Remove(article);
       }



    }

}

