using System;
using System.Collections.Generic;
using System.Text;


namespace JeSuisCatho.Web.API.Core.Models.User
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int UserTypeId { get; set; }
    }
}
