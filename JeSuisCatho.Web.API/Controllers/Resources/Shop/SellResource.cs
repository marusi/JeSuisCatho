using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Controllers.Resources.Shop
{
    public class SellResource
    {

  
        public int QuantityPerUnit { get; set; }

       
        public double UnitPrice { get; set; }

        public double Discount { get; set; }

        public int UnitWeight { get; set; }

        public int UnitInStock { get; set; }

        public int UnitsOnOrder { get; set; }
    }
}
