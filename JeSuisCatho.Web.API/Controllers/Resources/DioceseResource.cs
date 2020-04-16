using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class DioceseResource : KeyValuePairResource
    {
        public ICollection<DeaneryResource> Deaneries { get; set; }

        public DioceseResource()
        {
            Deaneries = new Collection<DeaneryResource>();
        }


    }
}
