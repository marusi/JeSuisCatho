using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    public class Cart
    {
        public string CartId { get; set; }

        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
