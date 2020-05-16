using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        public DbSet<Cart> Cart { get; set; }
        public  DbSet<CartItem> CartItems { get; set; }

        public  DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
        public  DbSet<CustomerOrders> CustomerOrders { get; set; }

        public DbSet<Post> Posts { get; set; }




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

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.CartItemId)
                    .HasName("PK__CartItem__488B0B0AA0297D1C");

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__Customer__9DD754DB9D819T221B");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Customer__C3905BFCF96C8F1E7");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CartTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });



        }









    }
}
