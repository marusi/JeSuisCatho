using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetDocuments();

        void Add(Document document);
    }
}
