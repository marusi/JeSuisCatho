using System.ComponentModel.DataAnnotations;
using System;


namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class AmbacoResource
    {

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string SubTitle { get; set; }

        [Required]
        [StringLength(12000)]
        public string Body { get; set; }

        public DateTime DateOfEvent { get; set; }

      
        [StringLength(255)]
        public string Duration { get; set; }


    }
}
