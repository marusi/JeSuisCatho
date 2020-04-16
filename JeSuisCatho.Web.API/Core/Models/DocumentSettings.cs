using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace JeSuisCatho.Web.API.Core.Models
{
    public class DocumentSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupported(string fileName)
        {
            return AcceptedFileTypes.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}
