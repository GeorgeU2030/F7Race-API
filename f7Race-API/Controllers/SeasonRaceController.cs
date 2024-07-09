using f7Race_API.Data;
using f7Race_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f7Race_API.Controller {

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Public")]
    public class SeasonRaceController : ControllerBase {

        private readonly F7Db _context;
        public SeasonRaceController(F7Db context){
            _context = context;
        }

        [HttpGet("{RaceId}")]
        public async Task<IActionResult> GetSeasonRace(int RaceId){
            var seasonRace = await _context.SeasonRaces
                .Where(x => x.SeasonRaceId == RaceId)
                .FirstOrDefaultAsync();

            if (seasonRace == null){
                return NotFound();
            }

        var response = new SeasonRaceresponse {
            SeasonRaceId = seasonRace.SeasonRaceId,
            SeasonId = seasonRace.SeasonId,
            Name = seasonRace.Name,
            FlagRace = seasonRace.FlagRace,
            Laps = seasonRace.Laps,
            ImageCircuit = seasonRace.ImageCircuit,
            FirstPosition = seasonRace.FirstPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.FirstPosition) : null,
            SecondPosition = seasonRace.SecondPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.SecondPosition) : null,
            ThirdPosition = seasonRace.ThirdPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.ThirdPosition) : null,
            FourthPosition = seasonRace.FourthPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.FourthPosition) : null,
            FifthPosition = seasonRace.FifthPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.FifthPosition) : null,
            SixthPosition = seasonRace.SixthPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.SixthPosition) : null,
            SeventhPosition = seasonRace.SeventhPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.SeventhPosition) : null,
            EighthPosition = seasonRace.EighthPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.EighthPosition) : null,
            NinthPosition = seasonRace.NinthPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.NinthPosition) : null,
            TenthPosition = seasonRace.TenthPosition != 0 ? await _context.SeasonBrands.FindAsync(seasonRace.TenthPosition) : null,
        };

        return Ok(response);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateSeasonRace(SeasonRace seasonRace){
            _context.SeasonRaces.Update(seasonRace);
            await _context.SaveChangesAsync();
            return Ok(seasonRace);
        }
    }
}