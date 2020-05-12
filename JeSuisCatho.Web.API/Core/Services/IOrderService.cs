using System;
using JeSuisCatho.Web.API.Core.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IOrderService
    {
        void CreateOrder(string userId, OrdersDto orderDetails);
        List<OrdersDto> GetOrderList(string userId);
    }
}
