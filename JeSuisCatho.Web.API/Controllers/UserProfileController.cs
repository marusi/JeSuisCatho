using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Shared;
using JeSuisCatho.Web.API.Persistence;
using AutoMapper;
using JeSuisCatho.Web.API.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace JeSuisCatho.Web.API.Controllers
{
    public class UserProfileController: Controller
    {

        private readonly JeSuisCathoDbContext context;
       
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProfileController(JeSuisCathoDbContext context, IHttpContextAccessor httpContextAccessor)
        {
           
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("/api/userprofile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.InvariantCultureIgnoreCase));
            var nameClaim = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals(ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase));
            var emailClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("Email", StringComparison.InvariantCultureIgnoreCase));



            if (idClaim != null )
            {

                //  string[] userProfile1 = new string[] { $"{idClaim.Value}", $"{nameClaim.Value}", $"{emailClaim.Value}" };

                var userName = Regex.Matches($"{nameClaim.Value}", @"([A-Z][a-z]+)").Cast<Match>().Select(m => m.Value);



                var spacedUserName = string.Join(" ", userName);

                var userProfile = new UserProfile()
                {
                    Id = idClaim.Value,
                    Name = spacedUserName,
                    Email = emailClaim.Value
                };
                await Task.CompletedTask;
                return Ok(userProfile);

            }
          
           

            return BadRequest("Sorry! We did not find any Profile Info. Are you sure you are logged in? :-}): ");
        }
    }
}
