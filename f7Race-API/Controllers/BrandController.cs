using f7Race_API.Custom;
using f7Race_API.Data;
using f7Race_API.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetBrands(){
            var brands = await _context.Brands.ToListAsync();
            return Ok(brands);
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
    }
}