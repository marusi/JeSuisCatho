using System;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace JeSuisCatho.Web.API.Persistence
{
    public class JeSuisCathoDbContext : IdentityDbContext
    {
        // tables, tabled 
        public DbSet<Location> Locations { get; set; }
        public DbSet<Archdiocese> Archdioceses { get; set; }
        public DbSet<Diocese> Dioceses { get; set; }
        public DbSet<Deanery> Deaneries { get; set; }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Church> Churches { get; set; }

        public DbSet<NewsEvent> NewsEvents { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }

        public DbSet<Article> Articles { get; set; }

        // SHOP tables
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        // public DbSet<SupplierStatusCode> SupplierStatusCodes { get; set; }

        public DbSet<SubCategoryItem> SubCategoryItems { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Document> Documents { get; set; }

      


        public JeSuisCathoDbContext(DbContextOptions<JeSuisCathoDbContext> options)
            : base(options) 
        {

         

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //al is short for articlelocation
            modelBuilder.Entity<ArticleLocation>().HasKey(al =>
                new { al.ArticleId, al.LocationId });
            modelBuilder.Entity<ProductSupplier>().HasKey(ps =>
                new { ps.ProductId, ps.SupplierId });
     


        }









    }
}
