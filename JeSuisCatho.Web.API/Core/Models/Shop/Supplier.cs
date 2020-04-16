using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    [Table("Suppliers")]
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string County { get; set; }
        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(70)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string URL { get; set; }
        [Required]
        [StringLength(255)]
        public string TypeGoods { get; set; }
        [Required]
        [StringLength(255)]
        public string Notes { get; set; }
        
        
        
    }
}
