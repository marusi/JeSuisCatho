using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    [Table("SubCategoryItems")]
    public class SubCategoryItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryItem CategoryItem { get; set;}

        public int CategoryItemId { get; set; }

      
    }
}