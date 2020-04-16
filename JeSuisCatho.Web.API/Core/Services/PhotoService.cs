using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPhotoStorage photoStorage;
        public PhotoService(IUnitOfWork unitOfWork, IPhotoStorage photoStorage)
        {
            this.photoStorage = photoStorage;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Photo> UploadPhoto(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.StorePhoto(uploadsFolderPath, file);

            var photo = new Photo { PhotoFileName = fileName };
            product.Photos.Add(photo);
            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}