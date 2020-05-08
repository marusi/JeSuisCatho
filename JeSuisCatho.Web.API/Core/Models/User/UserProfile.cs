using System;
using System.Collections.Generic;
using System.Text;


namespace JeSuisCatho.Web.API.Core.Models.User
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsLoggedIn { get; set; }

        public int CartCount { get; set; }
    }
}
