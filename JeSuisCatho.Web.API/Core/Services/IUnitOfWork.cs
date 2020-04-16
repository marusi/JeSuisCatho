using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}
