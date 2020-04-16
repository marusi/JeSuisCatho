using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IDocumentStorage
    {
         Task<string> StoreDocument(string uploadsFolderPath, IFormFile file);
    }
}