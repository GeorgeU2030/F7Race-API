using f7Race_API.Data;
using f7Race_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f7Race_API.Controller {

    [ApiController]
    [Authorize(Roles = "Public")]
    [Route("api/[controller]")]
    public class SeasonBrandController : ControllerBase {

        private readonly F7Db _context;
        public SeasonBrandController(F7Db context){
            _context = context;
        }

        [HttpPut("{BrandId}")]
        public async Task<IActionResult> UpdateBrand(int BrandId, [FromBody] int Points){

            var seasonBrand = await _context.SeasonBrands
                .Where(x => x.SeasonBrandId == BrandId)
                .FirstOrDefaultAsync();
            
            if (seasonBrand == null){
                return NotFound();
            }

            seasonBrand.Points += Points;

            await _context.SaveChangesAsync();

            return Ok(seasonBrand);
        }

    }

}