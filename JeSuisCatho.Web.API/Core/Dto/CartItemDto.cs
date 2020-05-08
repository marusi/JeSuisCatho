using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Core.Dto
{
    public class CartItemDto
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
