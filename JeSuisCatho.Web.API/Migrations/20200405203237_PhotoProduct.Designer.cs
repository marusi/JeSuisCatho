﻿// <auto-generated />
using System;
using JeSuisCatho.Web.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JeSuisCatho.Web.API.Migrations
{
    [DbContext(typeof(JeSuisCathoDbContext))]
    [Migration("20200405203237_PhotoProduct")]
    partial class PhotoProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Archdiocese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Archdioceses");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmbacoBody")
                        .IsRequired()
                        .HasMaxLength(12000);

                    b.Property<DateTime>("AmbacoDateOfEvent");

                    b.Property<string>("AmbacoDuration")
                        .HasMaxLength(255);

                    b.Property<string>("AmbacoSubTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("AmbacoTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsInvited");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("NewsCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("NewsCategoryId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.ArticleLocation", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("LocationId");

                    b.HasKey("ArticleId", "LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("ArticleLocations");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Church", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeaneryId");

                    b.Property<string>("DetailAddressLine");

                    b.Property<string>("DetailFatherInCharge");

                    b.Property<string>("DetailMailBox");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailWebsite");

                    b.Property<int>("DivisionId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("DeaneryId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("LocationId");

                    b.ToTable("Churches");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Deanery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DioceseId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DioceseId");

                    b.ToTable("Deaneries");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Diocese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArchdioceseId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ArchdioceseId");

                    b.ToTable("Dioceses");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.NewsCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("NewsEventId");

                    b.HasKey("Id");

                    b.HasIndex("NewsEventId");

                    b.ToTable("NewsCategories");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.NewsEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("NewsEvents");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.CategoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CategoryItems");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhotoFileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DiscountAvailable");

                    b.Property<string>("InfoNote")
                        .HasMaxLength(255);

                    b.Property<string>("InfoProductDescription")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("InfoProductName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("InfoVendorProductID");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<bool>("ProductAvailable");

                    b.Property<bool>("ProductOfSeason");

                    b.Property<double>("SellDiscount");

                    b.Property<int>("SellQuantityPerUnit");

                    b.Property<int>("SellUnitInStock");

                    b.Property<double>("SellUnitPrice");

                    b.Property<int>("SellUnitWeight");

                    b.Property<int>("SellUnitsOnOrder");

                    b.Property<int>("SubCategoryItemId");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryItemId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.ProductSupplier", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SupplierId");

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSuppliers");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.SubCategoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryItemId");

                    b.ToTable("SubCategoryItems");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TypeGoods")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Article", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.NewsCategory", "NewsCategory")
                        .WithMany()
                        .HasForeignKey("NewsCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.ArticleLocation", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Article")
                        .WithMany("Locations")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Church", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Deanery", "Deanery")
                        .WithMany()
                        .HasForeignKey("DeaneryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Deanery", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Diocese", "Diocese")
                        .WithMany("Deaneries")
                        .HasForeignKey("DioceseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Diocese", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Archdiocese", "Archdiocese")
                        .WithMany("Dioceses")
                        .HasForeignKey("ArchdioceseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.NewsCategory", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.NewsEvent", "NewsEvent")
                        .WithMany("NewsCategories")
                        .HasForeignKey("NewsEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.Photo", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Shop.Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.Product", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Shop.SubCategoryItem", "SubCategoryItem")
                        .WithMany()
                        .HasForeignKey("SubCategoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.ProductSupplier", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Shop.Product", "Product")
                        .WithMany("Suppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Shop.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JeSuisCatho.Web.API.Core.Models.Shop.SubCategoryItem", b =>
                {
                    b.HasOne("JeSuisCatho.Web.API.Core.Models.Shop.CategoryItem", "CategoryItem")
                        .WithMany("SubCategoryItems")
                        .HasForeignKey("CategoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
