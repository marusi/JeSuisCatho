using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;


namespace JeSuisCatho.Web.API.Controllers.Resources
{



    public class SaveArticleResource
    {

        public int Id { get; set; }

        public int NewsCategoryId { get; set; }

        // public int LocationId { get; set; }

        public bool IsInvited { get; set; }

    
        public AmbacoResource Ambaco { get; set; }

       
       

       // public DateTime LastUpdate { get; set; }

        public ICollection<int> Locations { get; set; }


        public SaveArticleResource()
        {
            Locations = new Collection<int>();
        }
    }
}
