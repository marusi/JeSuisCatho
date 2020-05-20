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

        public string ShipName { get; set; }
        public string ShipId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }

        public DateTime RequiredDate { get; set; }

        public string PaymentId { get; set; }
    }
}
