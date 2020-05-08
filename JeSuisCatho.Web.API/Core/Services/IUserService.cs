using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.ViewModel;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);

    
    }
}
