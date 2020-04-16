using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Core.Models
{

    [Table("Articles")]
    public class Article
    {
        public int Id { get; set; }

        public int NewsCategoryId { get; set; }

        public NewsCategory NewsCategory { get; set; }





        public bool IsInvited { get; set; }

        [Required]
        [StringLength(255)]
        public string AmbacoTitle { get; set; }
        [Required]
        [StringLength(255)]
        public string AmbacoSubTitle { get; set; }

        [Required]
        [StringLength(12000)]
        public string AmbacoBody { get; set; }

        public DateTime AmbacoDateOfEvent { get; set; }


        [StringLength(255)]
        public string AmbacoDuration { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<ArticleLocation> Locations { get; set; }


        public Article()
        {
            Locations = new Collection<ArticleLocation>();
        }
    }
}
