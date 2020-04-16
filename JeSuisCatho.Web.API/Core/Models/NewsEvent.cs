using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Models
{
    [Table("NewsEvents")]
    public class NewsEvent
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<NewsCategory> NewsCategories { get; set; }

        public NewsEvent()
        {
            NewsCategories = new Collection<NewsCategory>();
        }



    }
}
