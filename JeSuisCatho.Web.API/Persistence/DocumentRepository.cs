using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Persistence
{
    public class DocumentRepository: IDocumentRepository
    {
        private readonly JeSuisCathoDbContext context;
        public DocumentRepository(JeSuisCathoDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Document>> GetDocuments()
        {
            return await context.Documents.ToListAsync();
        }

        public void Add(Document document)
        {
            context.Documents.Add(document);

        }
    }
}
