using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DocumentFileName { get; set; }

        [Required]
        [StringLength(255)]
        public string EnglishDesc { get; set; }

        [Required]
        [StringLength(255)]
        public string FrenchDesc { get; set; }
    }
}
