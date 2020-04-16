using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;


namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    [Table("Products")]
    public class Product 
    {
        public int Id { get; set; }

        public int SubCategoryItemId { get; set; }
        
        public SubCategoryItem SubCategoryItem { get; set; }

        public bool ProductAvailable { get; set; }

        public bool DiscountAvailable { get; set; }

        public bool ProductOfSeason { get; set; }



        [Required]
        public int InfoVendorProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string InfoProductName { get; set; }

        [Required]
        [StringLength(255)]
        public string InfoProductDescription { get; set; }

        [StringLength(255)]
        public string InfoNote { get; set; }

        [Required]
        public int SellQuantityPerUnit { get; set; }

        [Required]
        public double SellUnitPrice { get; set; }

        public double SellDiscount { get; set; }

        public int SellUnitWeight { get; set; }

        [Required]
        public int SellUnitInStock { get; set; }

        public int SellUnitsOnOrder { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<ProductSupplier> Suppliers { get; set; }

        public Product()
        {
            Suppliers = new Collection<ProductSupplier>();
            Photos = new Collection<Photo>();
        }

    }
}