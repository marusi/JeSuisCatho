using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Controllers.Resources.Shop
{
    public class ProductResource
    {


        public int Id { get; set; }

        public KeyValuePairResource CategoryItem { get; set; }

        public KeyValuePairResource SubCategoryItem { get; set; }

        public bool ProductAvailable { get; set; }

        public bool DiscountAvailable { get; set; }

        public bool ProductOfSeason { get; set; }

        public SellResource Sell { get; set; }

      

        public InfoResource Info { get; set; }

        public DateTime LastUpdate { get; set; }


        public ICollection<SupplierResource> Suppliers { get; set; }



        public ProductResource()
        {
            Suppliers = new Collection<SupplierResource>();
           
           
        }
    }
}
