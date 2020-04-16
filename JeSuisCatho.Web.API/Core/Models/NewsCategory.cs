using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Models
{

    [Table("NewsCategories")]
    public class NewsCategory
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public NewsEvent NewsEvent { get; set; }

        public int NewsEventId { get; set; }


    }
}
