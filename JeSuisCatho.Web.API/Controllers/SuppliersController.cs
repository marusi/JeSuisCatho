
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Persistence;
using JeSuisCatho.Web.API.Controllers.Resources;
using JeSuisCatho.Web.API.Controllers.Resources.Shop;



namespace LissafiExpress.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly JeSuisCathoDbContext context;
        private readonly IMapper mapper;

        public SuppliersController(JeSuisCathoDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/suppliers")]

        public async Task<IEnumerable<SupplierResource>> GetSuppliers()
        {
            var suppliers = await context.Suppliers.ToListAsync();

            return mapper.Map<List<Supplier>, List<SupplierResource>>(suppliers);


        }

        [HttpGet("/api/categoryitems")]

        public async Task<IEnumerable<CategoryItemResource>> GetCategoryItems()
        {
            var categoryItems = await context.CategoryItems.Include(c => c.SubCategoryItems).ToListAsync();

            return mapper.Map<List<CategoryItem>, List<CategoryItemResource>>(categoryItems);


        }


    }
}
