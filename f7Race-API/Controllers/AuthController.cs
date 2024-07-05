using f7Race_API.Custom;
using f7Race_API.Data;
using f7Race_API.Models;
using f7Race_API.Models.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f7Race_API.Controllers {

    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase {

        private readonly F7Db _context;
        private readonly Utilities _utilities;
        public AuthController(F7Db context, Utilities utilities) {
            _context = context;
            _utilities = utilities;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register(SignUpDTO user){
            
            var userexists = await _context.Users.AnyAsync(x => x.Email == user.Email);
            
            if(userexists) return StatusCode(StatusCodes.Status409Conflict);

            var modelUser = new User {
                Name = user.Name,
                Email = user.Email,
                Password = _utilities.CrpytSHA256(user.Password),
                Role = "Public"
            };
            await _context.Users.AddAsync(modelUser);
            await _context.SaveChangesAsync();
            
            return StatusCode(StatusCodes.Status201Created, new {modelUser.UserId});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO user){
            var modelUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if(modelUser == null) return StatusCode(StatusCodes.Status404NotFound);

            if(modelUser.Password != _utilities.CrpytSHA256(user.Password)) return StatusCode(StatusCodes.Status401Unauthorized);
            
            var token = _utilities.GenerateJWTToken(modelUser);

            var userId = modelUser.UserId;
            
            return Ok(new {token, userId});
        }

        [HttpGet("validate")]
        public IActionResult ValidateToken([FromQuery]string token){
            var isValid = _utilities.ValidateJWTToken(token);
            return Ok(new {isValid});
        }

    }
    
}