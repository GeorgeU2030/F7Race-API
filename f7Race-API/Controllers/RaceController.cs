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
    public class RaceController : ControllerBase {

        private readonly F7Db _context;

        public RaceController(F7Db context){
            _context = context;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetRaces(int UserId){
            var races = await _context.Races
                .Where(x => x.UserId == UserId)
                .ToListAsync();
            return Ok(races);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddRace(int UserId){
            foreach (var race in RaceData.Races){
                race.UserId = UserId;
                _context.Races.Add(race);
            }
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}