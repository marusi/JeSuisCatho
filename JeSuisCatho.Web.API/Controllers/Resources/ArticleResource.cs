using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class ArticleResource
    {
        public int Id { get; set; }

       

        public KeyValuePairResource NewsCategory { get; set; }


        public KeyValuePairResource NewsEvent { get; set; }


        public bool IsInvited { get; set; }

      public AmbacoResource Ambaco{ get; set; }

     

        public DateTime LastUpdate { get; set; }

        public ICollection<KeyValuePairResource> Locations { get; set; }


        public ArticleResource()
        {
            Locations = new Collection<KeyValuePairResource>();
        }
    }
}
