
using System.Collections.Generic;
using JeSuisCatho.Web.API.Core.Dto;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface ICartService
    {
        void AddProductToCart(string userId, int productId);
        void RemoveCartItem(string userId, int productId);
        void DeleteOneCartItem(string userId, int productId);
        int GetCartItemCount(string userId);
        void MergeCart(string tempUserId, string permUserId);
        int ClearCart(string userId);
        string GetCartId(string userId);
    }
}
