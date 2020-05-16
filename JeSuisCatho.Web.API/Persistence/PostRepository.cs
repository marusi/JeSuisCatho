using System;
using System.Collections.Generic;
using System.Linq;

using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Persistence
{
    public class PostRepository : IPostRepository
    {
        private readonly JeSuisCathoDbContext context;

        public PostRepository(JeSuisCathoDbContext context)
        {
            this.context = context;

        }

        public async Task<Post> GetPost(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Posts.FindAsync(id);


            return await context.Posts

               .Include(a => a.NewsCategory)
                  .ThenInclude(n => n.NewsEvent)
              .SingleOrDefaultAsync(a => a.Id == id);

            
        }

        public void Add(Post post)
        {
            context.Posts.Add(post);

        }

        public void Remove(Post post)
        {
            context.Remove(post);
        }

    }
}
