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

namespace JeSuisCatho.Web.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArchDioceseController : Controller
    {

        private readonly JeSuisCathoDbContext context;
        private readonly IMapper mapper;

        public ArchDioceseController(JeSuisCathoDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/archdioceses")]
        public async Task<IEnumerable<ArchdioceseResource>> GetArchdioceses()
        {
            var archDioceses = await context.Archdioceses.Include(a => a.Dioceses).ThenInclude(b => b.Deaneries).ToListAsync();

           // var dioceses = await context.Dioceses.Include(b => b.Deaneries).ToListAsync();

            return mapper.Map<List<Archdiocese>, List<ArchdioceseResource>>(archDioceses);

        }

        [HttpGet("/api/divisions")]
        public async Task<IEnumerable<KeyValuePairResource>> GetDivisions()
        {
            var divisions = await context.Divisions.ToListAsync();

            return mapper.Map<List<Division>, List<KeyValuePairResource>>(divisions);
        }

        [HttpGet("/api/counties")]

        public async Task<IEnumerable<KeyValuePairResource>> GetLocations()
        {
            var locations = await context.Locations.ToListAsync();

            return mapper.Map<List<Location>, List<KeyValuePairResource>>(locations);

        }
    }
}
