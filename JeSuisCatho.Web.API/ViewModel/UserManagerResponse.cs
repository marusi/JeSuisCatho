using System;
using System.Collections.Generic;
using System.Text;


namespace JeSuisCatho.Web.API.ViewModel
{
   public class UserManagerResponse
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public DateTime? ExpiredDate { get; set; }

    
    }
}
