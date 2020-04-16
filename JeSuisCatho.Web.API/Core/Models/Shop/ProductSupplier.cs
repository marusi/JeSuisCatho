using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    [Table("ProductSuppliers")]
    public class ProductSupplier
    {
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
