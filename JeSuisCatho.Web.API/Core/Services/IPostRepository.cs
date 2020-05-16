using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IPostRepository
    {
        Task<Post> GetPost(int id, bool includeRelated = true);
        void Add(Post post);
        void Remove(Post post);

 
    }
}
