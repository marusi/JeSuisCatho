using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    public class CustomerOrders
    {
        public string OrderId { get; set; }
        public  string UserId { get; set; }

        public DateTime DateCreated { get; set; }
        public decimal CartTotal { get; set; }
    }
}
