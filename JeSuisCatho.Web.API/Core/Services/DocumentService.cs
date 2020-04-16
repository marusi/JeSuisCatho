using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Persistence;

namespace JeSuisCatho.Web.API.Core.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly JeSuisCathoDbContext context;
        private readonly IDocumentStorage documentStorage;
        public DocumentService(IUnitOfWork unitOfWork, IDocumentStorage documentStorage, JeSuisCathoDbContext context)
        {
            this.documentStorage = documentStorage;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Document> UploadDocument(string frenchDesc, string englishDesc,  IFormFile file, string uploadsFolderPath)
        {
            var fileName = await documentStorage.StoreDocument(uploadsFolderPath, file);

            var document = new Document { DocumentFileName = fileName, EnglishDesc = englishDesc, FrenchDesc = frenchDesc };
             context.Documents.Add(document);
            await unitOfWork.CompleteAsync();

            return document;
        }
    }
}