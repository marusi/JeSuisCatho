using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IArticleRepository
    {
        Task<Article> GetArticle(int id, bool includeRelated = true); 
        void Add(Article article);
        void Remove(Article article);
    }
}