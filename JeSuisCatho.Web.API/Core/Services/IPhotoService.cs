using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IPhotoService
    {
        Task<Photo> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath);
    }
}