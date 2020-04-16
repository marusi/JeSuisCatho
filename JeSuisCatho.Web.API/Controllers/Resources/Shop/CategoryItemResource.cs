using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;



namespace JeSuisCatho.Web.API.Controllers.Resources.Shop
{
    public class CategoryItemResource : KeyValuePairResource
    {
    

        public ICollection<KeyValuePairResource> SubCategoryItems { get; set;}

        public CategoryItemResource()
        {
            SubCategoryItems = new Collection<KeyValuePairResource>();
        }
    }
}