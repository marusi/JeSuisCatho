using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JeSuisCatho.Shared;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;

namespace JeSuisCatho.Web.API.Persistence
{
    public class UserRepository : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(UserManager<IdentityUser> userManager, IConfiguration configuration,  IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

       
        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("Register Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Passwords do not match",
                    IsSuccess = false
                };

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = $"{model.FirstName}{model.LastName}",
                
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if(result.Succeeded) {
                return new UserManagerResponse
                {
                    Message = "User Created Succesfuly",
                    IsSuccess = true,
                   
                };
            }
            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "We seem not to have your email on board :( SORRY!",
                    IsSuccess = false
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if(!result)
                return new UserManagerResponse
                {
                    Message = "Invalid Password detected :( SORRY!",
                    IsSuccess = false
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
               

            };
        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken
            (
               issuer: _configuration["AuthSettings:Issuer"],
               audience: _configuration["AuthSettings:Audience"],
               claims: claims,
               expires: DateTime.Now.AddDays(8),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

           
           

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
         

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpiredDate = token.ValidTo,
       

             };

        }
    }
}
