using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Controllers.Resources.Shop
{
    public class SaveProductResource
    {


        public int Id { get; set; }

       

        public int SubCategoryItemId { get; set; }

        public bool ProductAvailable { get; set; }

        public bool DiscountAvailable { get; set; }

        public SellResource Sell { get; set; }

        public InfoResource Info { get; set; }

  

        public ICollection<int> Suppliers { get; set; }


        public SaveProductResource()
        {
            Suppliers = new Collection<int>();
        }

    }
}
