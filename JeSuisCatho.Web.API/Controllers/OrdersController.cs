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
    public class OrdersController
    {
       private readonly IOrderService _orderService;
   
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

        /// <summary>
        /// Get the list of all the orders placed by a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<List<OrdersDto>> Get(string userId)
        {
            return await Task.FromResult(_orderService.GetOrderList(userId));
        }

    }
}
