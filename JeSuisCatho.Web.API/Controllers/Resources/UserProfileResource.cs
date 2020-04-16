using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class UserProfileResource : KeyValuePairResource
    {
        public string Email { get; set; }
    }
}
