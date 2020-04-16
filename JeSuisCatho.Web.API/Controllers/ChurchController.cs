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
using Microsoft.AspNetCore.Authorization;

namespace JeSuisCatho.Web.API.Controllers
{

        [Route("/api/churches")]
        [ApiController]
        [Authorize]
    public class ChurchController : Controller
        {


            private readonly IMapper mapper;
            private readonly IChurchRepository repository;
            private readonly IUnitOfWork unitOfWork;
            private readonly JeSuisCathoDbContext context;

            public ChurchController(IMapper mapper, IChurchRepository repository, IUnitOfWork unitOfWork, JeSuisCathoDbContext context)
            {
                this.mapper = mapper;
                this.repository = repository;
                this.unitOfWork = unitOfWork;
                this.context = context;

            }




            [HttpPost]
            public async Task<IActionResult> CreateGuardian([FromBody] SaveChurchResource churchResource)
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);




                var church= mapper.Map<SaveChurchResource, Church>(churchResource);
                church.LastUpdate = DateTime.Now;

                repository.Add(church);
                await unitOfWork.CompleteAsync();



                church = await repository.GetChurch(church.Id);

                var result = mapper.Map<Church, ChurchResource>(church);
                return Ok(result);
            }


            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateChurch(int id, [FromBody] SaveChurchResource churchResource)
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var church = await repository.GetChurch(id);

                if (church == null)
                    return NotFound();

                mapper.Map<SaveChurchResource, Church>(churchResource, church);
                church.LastUpdate = DateTime.Now;


                await unitOfWork.CompleteAsync();

                var result = mapper.Map<Church, ChurchResource>(church);
                return Ok(result);
            }



            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteChurch(int id)
            {
                var church = await repository.GetChurch(id, includeRelated: false);


                if (church == null)
                    return NotFound();


                repository.Remove(church);
                await unitOfWork.CompleteAsync();


                return Ok(id);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetChurch(int id)
            {
                var church = await repository.GetChurch(id);


                if (church == null)
                    return NotFound();

                var churchResource = mapper.Map<Church, ChurchResource>(church);

                return Ok(churchResource);
            }

            [HttpGet]

            public async Task<IEnumerable<ChurchResource>> GetChurch()
            {
                var churches = await context.Churches
                    .Include(c => c.Deanery)
                        .ThenInclude(d => d.Diocese)
                        .ThenInclude(a => a.Archdiocese)
                    .Include(c => c.Location)
                    .Include(c => c.Division)
                .ToListAsync();

                return mapper.Map<List<Church>, List<ChurchResource>>(churches);

            }

        }
    }
