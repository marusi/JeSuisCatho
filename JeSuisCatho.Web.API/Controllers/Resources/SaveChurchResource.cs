
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class SaveChurchResource
    {
        public int LocationId { get; set; }

        public int DivisionId { get; set; }
        public int DeaneryId { get; set; }
        public DetailResource Detail { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
