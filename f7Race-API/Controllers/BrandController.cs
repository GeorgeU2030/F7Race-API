using f7Race_API.Custom;
using f7Race_API.Data;
using f7Race_API.Models;
using f7Race_API.Models.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f7Race_API.Controllers {
    
    [ApiController]
    [Authorize(Roles = "Public")]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase {

        private readonly F7Db _context;
        public BrandController(F7Db context){
            _context = context;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetBrands(int UserId){
            var brands = await _context.Brands
                .Where(x => x.UserId == UserId)
                .ToListAsync();
            return Ok(brands);
        }

        [HttpGet("{brandId}/detail")]
        public async Task<ActionResult<Brand>> GetBrandDetail(int brandId){
            var brand = await _context.Brands
                .Where(x => x.BrandId == brandId)
                .Include(x => x.Trophies)
                    .ThenInclude(t => t.Race)
                .FirstOrDefaultAsync();

            if(brand == null){
                return NotFound();
            }

            brand.TrophiesCount = brand.Trophies
                .Where(t => t.Race != null) 
                .GroupBy(t => new { RaceName = t.Race?.Name ?? "Unknown", FlagRace = t.Race?.FlagRace ?? "no flag" })
                .Select(g => new TrophyCountDto
                {
                    RaceName = g.Key.RaceName,
                    FlagRace = g.Key.FlagRace,
                    Count = g.Count()
                }).ToList();

            return brand;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddBrand(int UserId){
            
            foreach (var brand in BrandData.Brands){
                brand.UserId = UserId;
                _context.Brands.Add(brand);
            }

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("stats")]
        public async Task<IActionResult> Stats(int UserId, string seasonBrandName, bool isWinner){
            
            var brand = await _context.Brands
                .Where(x => x.Name == seasonBrandName)
                .Where(x => x.UserId == UserId)
                .FirstOrDefaultAsync();
            
            if(brand == null){
                return NotFound();
            }

            if(isWinner){
                brand.TotalWins += 1;
            }

            brand.TotalPodiums += 1;

            await _context.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpPut("points")]
        public async Task<IActionResult> Points(int UserId, string seasonBrandName, int points){
            
            var brand = await _context.Brands
                .Where(x => x.Name == seasonBrandName)
                .Where(x => x.UserId == UserId)
                .FirstOrDefaultAsync();
            
            if(brand == null){
                return NotFound();
            }

            brand.TotalPoints += points;

            await _context.SaveChangesAsync();
            return Ok(brand);
        }


        [HttpPut("trophies")]
        public async Task<IActionResult> Trophies(int UserId, string seasonBrandName, string raceName){
            
            var brand = await _context.Brands
                .Where(x => x.Name == seasonBrandName)
                .Where(x => x.UserId == UserId)
                .FirstOrDefaultAsync();
            
            if(brand == null){
                return NotFound();
            }

            var race = await _context.Races
                .Where(x => x.Name == raceName)
                .Where(x => x.UserId == UserId)
                .FirstOrDefaultAsync();

            if(race == null){
                return NotFound();
            }

            var trophy = new Trophy {
                BrandId = brand.BrandId,
                Brand = brand,
                RaceId = race.RaceId,
                Race = race
            };

            brand.Trophies.Add(trophy);

            await _context.SaveChangesAsync();

            return Ok(brand);
        }

        [HttpPut("champion")]
        public async Task<IActionResult> Champion(int UserId, string seasonBrandName){
            var brand = await _context.Brands
                .Where(x => x.Name == seasonBrandName)
                .Where(x => x.UserId == UserId)
                .FirstOrDefaultAsync();
            
            if(brand == null){
                return NotFound();
            }

            brand.TotalChampions += 1;

            await _context.SaveChangesAsync();
            return Ok(brand);
        }
    }
}