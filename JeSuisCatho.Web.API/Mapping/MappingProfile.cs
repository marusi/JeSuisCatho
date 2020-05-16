using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JeSuisCatho.Web.API.Core.Models.User;
using JeSuisCatho.Web.API.Controllers.Resources;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Mapping
{
    public class MappingProfile : Profile
    {

        

        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Location, KeyValuePairResource>();
            CreateMap<Photo, PhotoResource>();
            CreateMap<Document, DocumentResource>();
            CreateMap<UserProfile, UserProfileResource>();
            CreateMap<Division, KeyValuePairResource>();
            CreateMap<Archdiocese, KeyValuePairResource>();
            CreateMap<Archdiocese, ArchdioceseResource>();
            CreateMap<Diocese, KeyValuePairResource>();
            CreateMap<Diocese, DioceseResource>();
            CreateMap<Deanery, DeaneryResource>();
            CreateMap<CategoryItem, CategoryItemResource>();
            CreateMap<CategoryItem, KeyValuePairResource>();
            CreateMap<SubCategoryItem, KeyValuePairResource>();
            CreateMap<Church, SaveChurchResource>()
           
         
                .ForMember(cr => cr.Detail, opt => opt.MapFrom(c => new DetailResource
                {
                    Name = c.DetailName,
                    FatherInCharge = c.DetailFatherInCharge,
                    AddressLine = c.DetailAddressLine,
                    MailBox = c.DetailMailBox,
                    Website = c.DetailWebsite
                }));
            CreateMap<Church, ChurchResource>()
               .ForMember(cr => cr.ArchDiocese, opt => opt.MapFrom(c => c.Deanery.Diocese.Archdiocese) )
               .ForMember(cr => cr.Diocese, opt => opt.MapFrom(c => c.Deanery.Diocese) )
               .ForMember(cr => cr.Location, opt => opt.MapFrom(c => c.Location))
               .ForMember(cr => cr.Division, opt => opt.MapFrom(c => c.Division))
               .ForMember(cr => cr.Detail, opt => opt.MapFrom(c => new DetailResource
               {
                   Name = c.DetailName,
                   FatherInCharge = c.DetailFatherInCharge,
                   AddressLine = c.DetailAddressLine,
                   MailBox = c.DetailMailBox,
                   Website = c.DetailWebsite
               }));

            CreateMap<NewsEvent, NewsEventResource>();
            CreateMap<NewsEvent, KeyValuePairResource>();
            CreateMap<NewsCategory, KeyValuePairResource>();
            CreateMap<Article, SaveArticleResource>()
               .ForMember(ar => ar.Ambaco, opt => opt.MapFrom(a => new AmbacoResource
               {
                   Title = a.AmbacoTitle,
                   SubTitle = a.AmbacoSubTitle,
                   Body = a.AmbacoBody,
                   DateOfEvent = a.AmbacoDateOfEvent,
                   Duration = a.AmbacoDuration
               }))
               .ForMember(ar => ar.Locations, opt => opt.MapFrom(a => a.Locations.Select(al => al.LocationId)));
            CreateMap<Article, ArticleResource>()
                .ForMember(al => al.NewsEvent, opt => opt.MapFrom(a => a.NewsCategory.NewsEvent))
                 .ForMember(ar => ar.Ambaco, opt => opt.MapFrom(a => new AmbacoResource
                 {
                     Title = a.AmbacoTitle,
                     SubTitle = a.AmbacoSubTitle,
                     Body = a.AmbacoBody,
                     DateOfEvent = a.AmbacoDateOfEvent,
                     Duration = a.AmbacoDuration
                 }))
                 .ForMember(ar => ar.Locations, opt => opt.MapFrom(a => a.Locations.Select(al => new KeyValuePairResource { Id = al.Location.Id, Name = al.Location.Name })));

            CreateMap<Post, SavePostResource>();
            CreateMap<Post, PostResource>()
                .ForMember(al => al.NewsEvent, opt => opt.MapFrom(a => a.NewsCategory.NewsEvent));



            CreateMap<Supplier, SupplierResource>();
            CreateMap<Product, SaveProductResource>()
                .ForMember(pr => pr.Info, opt => opt.MapFrom(p => new InfoResource
                {
                    VendorProductID = p.InfoVendorProductID,
                    ProductName = p.InfoProductName,
                    ProductDescription = p.InfoProductDescription,
                    Note = p.InfoNote
                }))
                .ForMember(pr => pr.Sell, opt => opt.MapFrom(p => new SellResource
                {
                    UnitPrice = p.SellUnitPrice,
                    QuantityPerUnit = p.SellQuantityPerUnit,
                    Discount = p.SellDiscount,
                    UnitWeight = p.SellUnitWeight,
                    UnitInStock = p.SellUnitInStock,
                    UnitsOnOrder = p.SellUnitsOnOrder
                }))
               .ForMember(pr => pr.Suppliers, opt => opt.MapFrom(p => p.Suppliers.Select(ps => ps.SupplierId)));
            CreateMap<Product, ProductResource>()
               .ForMember(pr => pr.CategoryItem, opt => opt.MapFrom(p => p.SubCategoryItem.CategoryItem))
               
          
                .ForMember(pr => pr.Info, opt => opt.MapFrom(p => new InfoResource
                {
                    VendorProductID = p.InfoVendorProductID,
                    ProductName = p.InfoProductName,
                    ProductDescription = p.InfoProductDescription,
                    Note = p.InfoNote
                }))
           
               .ForMember(pr => pr.Sell, opt => opt.MapFrom(p => new SellResource
               {
                   UnitPrice = p.SellUnitPrice,
                   QuantityPerUnit = p.SellQuantityPerUnit,
                   Discount = p.SellDiscount,
                   UnitWeight = p.SellUnitWeight,
                   UnitInStock = p.SellUnitInStock,
                   UnitsOnOrder = p.SellUnitsOnOrder
               }))
        
                .ForMember(pr => pr.Suppliers, opt => opt.MapFrom(p => p.Suppliers.Select(ps => new SupplierResource
                {
                    Id = ps.Supplier.Id,
                    CompanyName = ps.Supplier.CompanyName,
                    FirstName = ps.Supplier.FirstName,
                    LastName = ps.Supplier.LastName,
                    ContactTitle = ps.Supplier.ContactTitle,
                    Address1 = ps.Supplier.Address1,
                    Address2 = ps.Supplier.Address2,
                    City = ps.Supplier.City,
                    County = ps.Supplier.County,
                    PostalCode = ps.Supplier.PostalCode,
                    Email = ps.Supplier.Email,
                    MobileNo = ps.Supplier.MobileNo,
                    Notes = ps.Supplier.Notes,
                    TypeGoods = ps.Supplier.TypeGoods,
                    URL = ps.Supplier.URL
                })));
            //API Resource to Domain
            CreateMap<SaveProductResource, Product>()
               .ForMember(p => p.Id, opt => opt.Ignore())
               .ForMember(p => p.InfoVendorProductID, opt => opt.MapFrom(pr => pr.Info.VendorProductID))
               .ForMember(p => p.InfoProductName, opt => opt.MapFrom(pr => pr.Info.ProductName))
               .ForMember(p => p.InfoProductDescription, opt => opt.MapFrom(pr => pr.Info.ProductDescription))
               .ForMember(p => p.InfoNote, opt => opt.MapFrom(pr => pr.Info.Note))
               .ForMember(p => p.SellUnitPrice, opt => opt.MapFrom(pr => pr.Sell.UnitPrice))
               .ForMember(p => p.SellQuantityPerUnit, opt => opt.MapFrom(pr => pr.Sell.QuantityPerUnit))
               .ForMember(p => p.SellDiscount, opt => opt.MapFrom(pr => pr.Sell.Discount))
               .ForMember(p => p.SellUnitWeight, opt => opt.MapFrom(pr => pr.Sell.UnitWeight))
               .ForMember(p => p.SellUnitInStock, opt => opt.MapFrom(pr => pr.Sell.UnitInStock))
               .ForMember(p => p.SellUnitsOnOrder, opt => opt.MapFrom(pr => pr.Sell.UnitsOnOrder))
               .ForMember(p => p.Suppliers, opt => opt.Ignore())
               .AfterMap((ps, p) => {
                    // Remove unselected Location
                    var removedSuppliers = p.Suppliers.Where(s => !ps.Suppliers.Contains(s.SupplierId));
                   foreach (var s in removedSuppliers)
                       p.Suppliers.Remove(s);

                    // Add new features
                    var addedSuppliers = ps.Suppliers.Where(id => !p.Suppliers.Any(s => s.SupplierId == id)).Select(id => new ProductSupplier { SupplierId = id });
                   foreach (var s in addedSuppliers)
                       p.Suppliers.Add(s);
               });



            CreateMap<SaveArticleResource, Article>()
                 .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.AmbacoTitle, opt => opt.MapFrom(ar => ar.Ambaco.Title))
                .ForMember(a => a.AmbacoSubTitle, opt => opt.MapFrom(ar => ar.Ambaco.SubTitle))
                .ForMember(a => a.AmbacoBody, opt => opt.MapFrom(ar => ar.Ambaco.Body))
                .ForMember(a => a.AmbacoDateOfEvent, opt => opt.MapFrom(ar => ar.Ambaco.DateOfEvent))
                .ForMember(a => a.AmbacoDuration, opt => opt.MapFrom(ar => ar.Ambaco.Duration))
                .ForMember(a => a.Locations, opt => opt.Ignore())
                .AfterMap((al, a) => {
                    // Remove unselected Location
                    var removedLocations = a.Locations.Where(l => !al.Locations.Contains(l.LocationId));
                    foreach (var l in removedLocations)
                        a.Locations.Remove(l);

                    // Add new features
                    var addedLocations = al.Locations.Where(id => !a.Locations.Any(l => l.LocationId == id)).Select(id => new ArticleLocation { LocationId = id });
                    foreach (var l in addedLocations)
                        a.Locations.Add(l);
                });

            CreateMap<SavePostResource, Post>()
                .ForMember(a => a.Id, opt => opt.Ignore());

            CreateMap<SaveChurchResource, Church>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.DetailName, opt => opt.MapFrom(cr => cr.Detail.Name))
                .ForMember(c => c.DetailFatherInCharge, opt => opt.MapFrom(cr => cr.Detail.FatherInCharge))
                .ForMember(c => c.DetailAddressLine, opt => opt.MapFrom(cr => cr.Detail.AddressLine))
                .ForMember(c => c.DetailMailBox, opt => opt.MapFrom(cr => cr.Detail.MailBox))
                .ForMember(c => c.DetailWebsite, opt => opt.MapFrom(cr => cr.Detail.Website));

        }

        
    }
}
