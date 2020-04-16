
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Persistence;

namespace  JeSuisCatho.Web.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JeSuisCathoDbContext context;

        public UnitOfWork(JeSuisCathoDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
