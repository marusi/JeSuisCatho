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
    public class ChurchRepository : IChurchRepository
    {
        private readonly JeSuisCathoDbContext context;

        public ChurchRepository(JeSuisCathoDbContext context)
        {
            this.context = context;
        }

        public async Task<Church> GetChurch(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Churches.FindAsync(id);


            return await context.Churches

             .Include(c => c.Deanery)
                  .ThenInclude(d => d.Diocese).ThenInclude(a => a.Archdiocese)
                    .Include(c => c.Location)
                    .Include(c => c.Division)


              .SingleOrDefaultAsync(c => c.Id == id);

        }

        public void Add(Church church)
        {
            context.Churches.Add(church);

        }

        public void Remove(Church church)
        {
            context.Remove(church);
        }
    }



}