

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;
using System.Linq;

namespace JeSuisCatho.Web.API.Persistence
{

    public class ProductRepository : IProductRepository
    {
        private readonly JeSuisCathoDbContext context;

        public ProductRepository(JeSuisCathoDbContext context)
        {
            this.context = context;

        }

        public async Task<Product> GetProduct(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Products.FindAsync(id);


            return await context.Products
             .Include(p => p.Suppliers)
                 .ThenInclude(ps => ps.Supplier)
             .Include(p => p.SubCategoryItem)
                  .ThenInclude(c => c.CategoryItem)
              
              .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductBySeason(bool productOfSeason = true, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Products.FindAsync(productOfSeason);


            return await context.Products
             .Include(p => p.Suppliers)
                 .ThenInclude(ps => ps.Supplier)
             .Include(p => p.SubCategoryItem)
                  .ThenInclude(c => c.CategoryItem)
              .SingleOrDefaultAsync(p => p.ProductOfSeason == productOfSeason);
        }
       

        public void Add(Product product)
        {
            context.Products.Add(product);

        }

        public void Remove(Product product)
        {
            context.Remove(product);
        }
    }
 
 
            
    }

