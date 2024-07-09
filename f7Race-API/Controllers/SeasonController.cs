using f7Race_API.Custom;
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

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetSeasons(int UserId){
            
            var seasons = await _context.Seasons
                .Where(x => x.UserId == UserId)
                .Include(x => x.Winner)
                .Include(x => x.Second)
                .Include(x => x.Third)
                .OrderByDescending(x => x.SeasonId)
                .ToListAsync();

            return Ok(seasons);
        }

        [HttpGet("{id}/detail")]
        public async Task<ActionResult<Season>> GetSeasonDetail(int id){
            
            var season = await _context.Seasons
                .Where(x => x.SeasonId == id)
                .Include(x => x.Brands)
                .Include(x => x.Races)
                .Include(x => x.Winner)
                .Include(x => x.Second)
                .Include(x => x.Third)
                .FirstOrDefaultAsync();

            if (season == null){
                return NotFound();
            }

            return season;
        }

        [HttpPost]
        public async Task<IActionResult> AddSeason(Season season){
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, season);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddTeamtoSeason(int id, SeasonBrand brand){
            
            var season = await _context.Seasons.FindAsync(id);

            if (season == null){
                return NotFound();
            }

            season.Brands.Add(brand);

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}/races")]
        public async Task<IActionResult> AddRacetoSeason(int id, SeasonRace seasonrace){

            var season = await _context.Seasons.FindAsync(id);

            if (season == null){
                return NotFound();
            }

            season.Races.Add(seasonrace);

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}