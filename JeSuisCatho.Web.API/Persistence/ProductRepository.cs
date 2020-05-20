

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;
using System.Linq;
using JeSuisCatho.Web.API.Core.Dto;
using System.Collections.Generic;


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

        public async Task<IEnumerable<Photo>> GetPhotos(int id)
        {
            return await context.Photos
              .Where(p => p.ProductId == id)
              .ToListAsync();
        }

        public void Add(Photo photo)
        {
            context.Photos.Add(photo);

        }

        public Product GetProductData(int id)
        {
            try
            {
               

                Product product = context.Products.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    context.Entry(product).State = EntityState.Detached;
                    return product;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
        public List<CartItemDto> GetProductsAvailableInCart(string cartID)
        {
            try
            {
                List<CartItemDto> cartItemList = new List<CartItemDto>();
                List<CartItem> cartItem = context.CartItems.Where(x => x.CartId == cartID).ToList();

                foreach (CartItem item in cartItem)
                {
                    Product product = GetProductData(item.ProductId);
                    CartItemDto objCartItem = new CartItemDto
                    {
                        Product = product,
                        Quantity = item.Quantity
                    };

                    cartItemList.Add(objCartItem);
                }
                return cartItemList;
            }
            catch
            {
                throw;
            }
        }

        public void Remove(Product product)
        {
            context.Remove(product);
        }
    }
 
 
            
    }

