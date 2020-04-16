using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class DocumentResource
    {
        public int Id { get; set; }

        public string DocumentFileName { get; set; }

       public string EnglishDesc { get; set; }
       public string FrenchDesc { get; set; }

    }


}