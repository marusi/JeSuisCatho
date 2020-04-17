using System.ComponentModel.DataAnnotations;

namespace JeSuisCatho.Web.API.Core.Models.Shop
{
    public class Photo
    {
        public int Id { get; set; }

  

        [Required]
        [StringLength(255)]
        public string PhotoFileName { get; set; }

     
        public int ProductId { get; set; }
    }
}