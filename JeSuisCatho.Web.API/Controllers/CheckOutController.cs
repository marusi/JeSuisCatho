using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JeSuisCatho.Web.API.Core.Dto;
using JeSuisCatho.Web.API.Core.Services;

namespace JeSuisCatho.Web.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CheckOutController : Controller
    {
      private  readonly IOrderService _orderService;
      private  readonly ICartService _cartService;

      public CheckOutController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        /// <summary>
        /// Checkout from shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="checkedOutItems"></param>
        /// <returns></returns>
        [HttpPost("{userId}")]
        public int Post(string userId, [FromBody]OrdersDto checkedOutItems)
        {
            _orderService.CreateOrder(userId, checkedOutItems);
            return _cartService.ClearCart(userId);
        }
    }
}
