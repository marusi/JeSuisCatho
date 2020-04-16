using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace JeSuisCatho.Web.API.Core.Models
{
    [Table("ArticleLocations")]
    public class ArticleLocation
    {
        

        public int LocationId { get; set; }

        public int ArticleId { get; set; }

      //  private Article Article { get; set; }

        public Location Location { get; set; }

    

        

    }
}
