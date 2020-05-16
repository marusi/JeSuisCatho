using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int productId);

        void Add(Photo photo);
    }
}
