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
    public class ChurchResource
    {
        public int Id { get; set; }

        public KeyValuePairResource ArchDiocese { get; set; }
        public KeyValuePairResource Diocese { get; set; }
        public KeyValuePairResource Deanery { get; set; }
        public KeyValuePairResource Location { get; set; }
        public KeyValuePairResource Division { get; set; }

        public DetailResource Detail { get; set; }
    }
}
