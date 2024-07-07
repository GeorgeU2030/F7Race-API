using f7Race_API.Data;
using f7Race_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f7Race_API.Controller {
    
    [ApiController]
    [Authorize(Roles = "Public")]
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase {

        private readonly F7Db _context;

        public SeasonController(F7Db context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeasons(){
            
            var seasons = await _context.Seasons
                .Include(x => x.Winner)
                .Include(x => x.Second)
                .Include(x => x.Third)
                .OrderByDescending(x => x.SeasonId)
                .ToListAsync();

            return Ok(seasons);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeason(Season season){
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}