using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Core.Services
{
   public interface IChurchRepository
    {
        Task<Church> GetChurch(int id, bool includeRelated = true);
        void Add(Church church);
        void Remove(Church church);
        
    }
}
