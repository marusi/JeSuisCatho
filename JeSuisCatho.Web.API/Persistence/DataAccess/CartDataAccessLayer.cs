using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeSuisCatho.Web.API.Persistence.DataAccess
{
    public class CartDataAccessLayer : ICartService
    {
        readonly JeSuisCathoDbContext _dbContext;

        public CartDataAccessLayer(JeSuisCathoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductToCart(string userId, int productId)
        {
            string cartId = GetCartId(userId);
            int quantity = 1;

            CartItem existingCartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                _dbContext.Entry(existingCartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                CartItem cartItems = new CartItem
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity
                };
                _dbContext.CartItems.Add(cartItems);
                _dbContext.SaveChanges();
            }
        }

        public string GetCartId(string userId)
        {
            try
            {
                Cart cart = _dbContext.Cart.FirstOrDefault(x => x.UserId == userId);

                if (cart != null)
                {
                    return cart.CartId;
                }
                else
                {
                    return CreateCart(userId);
                }

            }
            catch
            {
                throw;
            }
        }

        string CreateCart(string userId)
        {
            try
            {
                Cart shoppingCart = new Cart
                {
                    CartId = Guid.NewGuid().ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date
                };

                _dbContext.Cart.Add(shoppingCart);
                _dbContext.SaveChanges();

                return shoppingCart.CartId;
            }
            catch
            {
                throw;
            }
        }

        public void RemoveCartItem(string userId, int productId)
        {
            try
            {
                string cartId = GetCartId(userId);
                CartItem cartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

                _dbContext.CartItems.Remove(cartItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOneCartItem(string userId, int productId)
        {
            try
            {
                string cartId = GetCartId(userId);
                CartItem cartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

                cartItem.Quantity -= 1;
                _dbContext.Entry(cartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int GetCartItemCount(string userId)
        {
            string cartId = GetCartId(userId);

            if (!string.IsNullOrEmpty(cartId))
            {
                int cartItemCount = _dbContext.CartItems.Where(x => x.CartId == cartId).Sum(x => x.Quantity);

                return cartItemCount;
            }
            else
            {
                return 0;
            }
        }

        public void MergeCart(string tempUserId, string permUserId)
        {
            try
            {
                if (tempUserId != permUserId)
                {
                    string tempCartId = GetCartId(tempUserId);
                    string permCartId = GetCartId(permUserId);

                    List<CartItem> tempCartItems = _dbContext.CartItems.Where(x => x.CartId == tempCartId).ToList();

                    foreach (CartItem item in tempCartItems)
                    {
                        CartItem cartItem = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == item.ProductId && x.CartId == permCartId);

                        if (cartItem != null)
                        {
                            cartItem.Quantity += item.Quantity;
                            _dbContext.Entry(cartItem).State = EntityState.Modified;
                        }
                        else
                        {
                            CartItem newCartItem = new CartItem
                            {
                                CartId = permCartId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity
                            };
                            _dbContext.CartItems.Add(newCartItem);
                        }
                        _dbContext.CartItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                    DeleteCart(tempCartId);
                }
            }
            catch
            {
                throw;
            }
        }

        public int ClearCart(string userId)
        {
            try
            {
                string cartId = GetCartId(userId);
                List<CartItem> cartItem = _dbContext.CartItems.Where(x => x.CartId == cartId).ToList();

                if (!string.IsNullOrEmpty(cartId))
                {
                    foreach (CartItem item in cartItem)
                    {
                        _dbContext.CartItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        void DeleteCart(string cartId)
        {
            Cart cart = _dbContext.Cart.Find(cartId);
            _dbContext.Cart.Remove(cart);
            _dbContext.SaveChanges();
        }
    }
}
