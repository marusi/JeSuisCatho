using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class DetailResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string FatherInCharge { get; set; }
        [Required]
        [StringLength(255)]
        public string MailBox { get; set; }
        [Required]
        [StringLength(255)]
        public string AddressLine { get; set; }

        [Required]
        [StringLength(50)]
        public string Website { get; set; }
    }
}
