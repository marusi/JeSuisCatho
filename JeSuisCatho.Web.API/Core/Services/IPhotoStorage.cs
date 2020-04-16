using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IPhotoStorage
    {
         Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}