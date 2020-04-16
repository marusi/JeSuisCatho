using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace JeSuisCatho.Web.API.Core.Models
{
    [Table("Churches")]
    public class Church
    {
        public int Id { get; set; }

        public int DeaneryId { get; set; }

        public Deanery Deanery { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int DivisionId { get; set; }

        public Division Division { get; set; }

        public string DetailName { get; set; }

        public string DetailFatherInCharge { get; set; }

        public  string DetailMailBox { get; set; }

        public string DetailAddressLine  { get; set; }

        public string DetailWebsite { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}
