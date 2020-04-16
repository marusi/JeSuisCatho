using System.Collections.Generic;
using System.Collections.ObjectModel;
using JeSuisCatho.Web.API.Core.Models.Shop;



namespace  JeSuisCatho.Web.API.Core.Models.Shop
{
    public class CategoryItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubCategoryItem> SubCategoryItems { get; set;}

        public CategoryItem()
        {
            SubCategoryItems = new Collection<SubCategoryItem>();
        }
    }
}