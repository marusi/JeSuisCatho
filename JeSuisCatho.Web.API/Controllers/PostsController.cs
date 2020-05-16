using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models;
using JeSuisCatho.Web.API.Persistence;
using JeSuisCatho.Web.API.Controllers.Resources;
using JeSuisCatho.Shared.CALCULATIONS;
using Microsoft.AspNetCore.Authorization;

namespace JeSuisCatho.Web.API.Controllers
{

    [Route("/api/posts")]

    [ApiController]
  //  [Authorize]
    public class PostsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPostRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly JeSuisCathoDbContext context;

        public PostsController(JeSuisCathoDbContext context, IMapper mapper, IPostRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.context = context;

        }

       /* [HttpGet]

        public async Task<IEnumerable<PostResource>> GetPosts()
        {
         

            var posts= await context.Posts
              
                .Include(a => a.NewsCategory)
                    .ThenInclude(n => n.NewsEvent)
                .ToListAsync();

            return mapper.Map<List<Post>, List<PostResource>>(posts);

        } */

        [HttpGet]

        public async Task<IActionResult> GetGalleryLocations()
        {
            var myLat = 25.79;
            var myLon = -80.13;
            var radiusInMile = 50;
            var minMilePerLat = 68.703;
            var milePerLon = Math.Cos(myLat) * 69.172;
            var minLat = Math.Min(myLat - radiusInMile / minMilePerLat, myLat + radiusInMile / minMilePerLat);
            var maxLat = Math.Max(myLat - radiusInMile / minMilePerLat, myLat + radiusInMile / minMilePerLat);
            var minLon = Math.Min(myLon - radiusInMile / milePerLon, myLon + radiusInMile / milePerLon);
            var maxLon = Math.Max(myLon - radiusInMile / milePerLon, myLon + radiusInMile / milePerLon);

            var calc = new DistanceCalc();

            var data = context.Posts
                 .Include(a => a.NewsCategory)
                    .ThenInclude(n => n.NewsEvent)
                .Where(p => (minLat <= p.Lat && p.Lat <= maxLat) && (minLon <= p.Lng && p.Lng <= maxLon))
                   .AsEnumerable()
                   .Select(p => new { p, Dist = calc.distanceInMiles(myLon, myLat, p.Lng, p.Lat) })
                   .Where(p => p.Dist <= radiusInMile)
                .ToList();
            await Task.CompletedTask;
            return Ok(data);
        }

    }
}
