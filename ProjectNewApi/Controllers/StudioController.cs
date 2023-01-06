using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectNewApi.Context;
using ProjectNewApi.Models;
using System;
using System.Threading.Tasks;

namespace ProjectNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public StudioController(AppDbContext authContext)
        {
            _authContext = authContext;
        }

        [HttpGet]
        [Route("GetAllStudios")]
        public async Task<ActionResult<Studio>> GetAllStudios()
        {
            return Ok(await _authContext.Studios.Include(instruktori => instruktori.Instruktori).Include(nameof(Lokacija)).ToListAsync());
        }
        [HttpGet]
        [Route("GetStudioById/{studioId:int}")]
        public async Task<ActionResult<Studio>> GetStudioById(int studioId)
        {
            var studio = await _authContext.Studios.Include(instruktori => instruktori.Instruktori).Include(nameof(Lokacija)).FirstOrDefaultAsync(x => x.StudioId == studioId);
            if (studio == null)
            {
                return Ok(new { Message = "There is no registered studios with this id!" });
            }
            return Ok(studio);
        }


        [HttpGet]
        [Route("GetInstructorsForStudio/{studioId:int}")]
        public async Task<ActionResult<Studio>> GetInstructorsForStudio(int studioId)
        {
            var studio = await _authContext.Studios.Include(instruktori => instruktori.Instruktori).Include(nameof(Lokacija)).FirstOrDefaultAsync(x => x.StudioId == studioId);
            if (studio == null)
                return Ok(new { Message = "Ne postoji studio sa ovim id!" });

            var instruktori = studio.Instruktori.ToArray();
            if (instruktori.Length == 0)
                return Ok(new { Message = "Nema isntruktora za ovaj studio!" });

            return Ok(instruktori);
        }


        [HttpPost]
        [Route("AddStudio")]
        public async Task<IActionResult> AddStudio([FromBody] Studio studioObj)
        {
            if (studioObj == null)
            {
                return BadRequest();
            }
            
            await _authContext.Studios.AddAsync(studioObj);
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "Studio registered"! });
        }


        [HttpPut]
        [Route("AddOwner/{studioId:int}")]
        public async Task<ActionResult<Studio>> SetOwner(int studioId,int userId)
        {
            var studio = await _authContext.Studios.Include(instruktori => instruktori.Instruktori).Include(nameof(Lokacija)).FirstOrDefaultAsync(x => x.StudioId == studioId);
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (studio == null)
            {
                return Ok(new { Message = "There is no registered studios with this id!" });
            }
            if (user == null)
            {
                return Ok(new { Message = "There is no registered user with this id!" });
            }
            user.Role = "Vlasnik";
            studio.VlasnikId = userId;
          
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "Vlasnik registrovan"! });
        }
        [HttpPut]
        [Route("AddInstructor/{userId:int}")]
        public async Task<ActionResult<Studio>> AddInstructor(int studioId, int userId)
        {
            var studio = await _authContext.Studios.FirstOrDefaultAsync(x => x.StudioId == studioId);
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (studio == null)
            {
                return Ok(new { Message = "There is no registered studios with this id!" });
            }
            if (user == null)
            {
                return Ok(new { Message = "There is no registered user with this id!" });
            }
            user.Role = "Instruktor";
            await _authContext.SaveChangesAsync();

            studio.Instruktori.Add(user);

            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "Instruktor  prijavljen"! });
        }

       
    }
}
