using System.Collections.Generic;
using System.Threading.Tasks;

using JeSuisCatho.Web.API.Core.Dto;
using JeSuisCatho.Web.API.Core.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;

using System.Linq;


using Microsoft.EntityFrameworkCore;
using AutoMapper;

using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Persistence;
using JeSuisCatho.Web.API.Controllers.Resources;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;


namespace JeSuisCatho.Web.API.Controllers
{

    [Route("api/cart/")]

    public class CartController : Controller
    {
        readonly ICartService _cartService;

        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly JeSuisCathoDbContext context;




        public CartController(JeSuisCathoDbContext context, IMapper mapper, IProductRepository repository, 
                                IPhotoRepository photoRepository, IUnitOfWork unitOfWork, ICartService _cartService)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.photoRepository = photoRepository;
            this.unitOfWork = unitOfWork;
            this.context = context;
            this._cartService = _cartService;
        }


        /// <summary>
        /// Get the shopping cart for a user upon Login. If the user logs in for the first time, creates the shopping cart.
        /// </summary>
        /// <param name="oldUserId"></param>
        /// <param name="newUserId"></param>
        /// <returns>The count of items in shopping cart</returns>
        [Authorize]
        [HttpGet]
        [Route("SetShoppingCart/{oldUserId}/{newUserId}")]
        public int Get(string oldUserId, string newUserId)
        {
            _cartService.MergeCart(oldUserId, newUserId);
            return _cartService.GetCartItemCount(newUserId);
        }
        /// <summary>
        /// Get the list of items in the shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<List<CartItemDto>> Get(string userId)
        {
            string cartid = _cartService.GetCartId(userId);
            return await Task.FromResult(repository.GetProductsAvailableInCart(cartid));

        }

        /// <summary>
        /// Add a single item into the shopping cart. If the item already exists, increase the quantity by one
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns>Count of items in the shopping cart</returns>
        [HttpPost]
        [Route("AddToCart/{userId}/{productId}")]
        public int Post(string userId, int productId)
        {
            _cartService.AddProductToCart(userId, productId);
            return _cartService.GetCartItemCount(userId);
        }

        /// <summary>
        /// Reduces the quantity by one for an item in shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPut("{userId}/{productId}")]
        public int Put(string userId, int productId)
        {
            _cartService.DeleteOneCartItem(userId, productId);
            return _cartService.GetCartItemCount(userId);
        }
        /// <summary>
        /// Delete a single item from the cart 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}/{productId}")]
        public int Delete(string userId, int productId)
        {
            _cartService.RemoveCartItem(userId, productId);
            return _cartService.GetCartItemCount(userId);
        }

        /// <summary>
        /// Clear the shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public int Delete(string userId)
        {
            return _cartService.ClearCart(userId);
        }
    }

}
