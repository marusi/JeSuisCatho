using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Persistence;
using AutoMapper;
using JeSuisCatho.Web.API.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace JeSuisCatho.Web.API.Controllers
{
    
    [ApiController]
    [Authorize]
    public class AmbacoController : Controller
    {
        private readonly JeSuisCathoDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

       public AmbacoController(JeSuisCathoDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("/api/newsandevents")]

        public async Task<IEnumerable<NewsEventResource>> GetNewsEvents()
        {
            var newsEvents = await context.NewsEvents.Include(n => n.NewsCategories).OrderByDescending(n => n.Id).ToListAsync();
            // .GroupBy(n => n.Id).Select(n => n.OrderByDescending(y => y.Id))
            return mapper.Map<List<NewsEvent>, List<NewsEventResource>>(newsEvents);

        }
      
    }
}
