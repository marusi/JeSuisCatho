using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class ArchdioceseResource: KeyValuePairResource
    {
        public ICollection<DioceseResource> Dioceses { get; set; }

        public ArchdioceseResource()
        {
            Dioceses = new Collection<DioceseResource>();
        }
    }
}
