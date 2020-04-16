using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Core.Services;


namespace JeSuisCatho.Web.API.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly JeSuisCathoDbContext context;
        public PhotoRepository(JeSuisCathoDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Photo>> GetPhotos(int productId)
        {
            return await context.Photos
              .Where(p => p.ProductId == productId)
              .ToListAsync();
        }
    }
}