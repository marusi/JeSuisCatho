using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IDocumentService
    {
        Task<Document> UploadDocument(string frenchDesc, string englishDesc, IFormFile file, string uploadsFolderPath);

       
    }
}