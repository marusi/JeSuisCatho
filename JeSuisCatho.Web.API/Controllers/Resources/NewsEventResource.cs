using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;



namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class NewsEventResource : KeyValuePairResource
    {

    
        public ICollection<KeyValuePairResource> NewsCategories { get; set; }

        public NewsEventResource()
        {
            NewsCategories = new Collection<KeyValuePairResource>();
        }

    }
}
