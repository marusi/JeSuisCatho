using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeSuisCatho.Web.API.Core.Models
{
    [Table("Dioceses")]
    public class Diocese
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Archdiocese Archdiocese { get; set; }
        public int ArchdioceseId { get; set; }

        public ICollection<Deanery> Deaneries { get; set; }

        public Diocese()
        {
            Deaneries = new Collection<Deanery>();
        }


    }
}
