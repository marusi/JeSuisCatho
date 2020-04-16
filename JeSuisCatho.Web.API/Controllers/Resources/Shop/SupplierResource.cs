using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;


namespace JeSuisCatho.Web.API.Controllers.Resources.Shop
{ 
   
    public class SupplierResource
    {
     

        public int Id { get; set; }
        
     
        public string CompanyName { get; set; }
  
        public string FirstName { get; set; }

        public string LastName { get; set; }
    
        public string ContactTitle { get; set; }
       
        public string Address1 { get; set; }

        public string Address2 { get; set; }
     
        public string City { get; set; }
    
        public string County { get; set; }
       
        public string PostalCode { get; set; }

      
        public string MobileNo { get; set; }
      
        public string Email { get; set; }
      
        public string URL { get; set; }
       
        public string TypeGoods { get; set; }
    
        public string Notes { get; set; }
        
        
        
    }
}
