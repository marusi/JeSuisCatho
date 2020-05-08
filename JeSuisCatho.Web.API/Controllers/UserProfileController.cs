using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Models.User;
using JeSuisCatho.Web.API.Persistence;
using AutoMapper;
using JeSuisCatho.Web.API.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using JeSuisCatho.Web.API.Core.Services;

namespace JeSuisCatho.Web.API.Controllers
{
    public class UserProfileController: Controller
    {

        private readonly JeSuisCathoDbContext context;
       
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartService _cartService;
        private readonly IUserService _userService;

        public UserProfileController(JeSuisCathoDbContext context, ICartService cartService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
           
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
            _cartService = cartService;
            _userService = userService;
        }

        /// <summary>
        /// Get the count of item in the shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The count of items in shopping cart</returns>
        [HttpGet("/api/user/{userId}")]
        public int Get(string userId)
        {
            int cartItemCount = _cartService.GetCartItemCount(userId);
            return cartItemCount;
        }

        /// <summary>
        /// Check the availability of the username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
     


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
                    Email = emailClaim.Value,
                    IsLoggedIn = true,
                    CartCount = Get(idClaim.Value)
                };
                await Task.CompletedTask;
                return Ok(userProfile);

            }
          
           

            return BadRequest("Sorry! We did not find any Profile Info. Are you sure you are logged in? :-}): ");
        }
    }
}
