using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeSuisCatho.Web.API.Core.Models
{

    [Table("Archdioceses")]
    public class Archdiocese
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } 

        public ICollection<Diocese> Dioceses { get; set; }

        public Archdiocese()
        {
            Dioceses = new Collection<Diocese>();
        }
    }
}
