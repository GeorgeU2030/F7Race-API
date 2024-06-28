using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using dotenv.net;
using f7Race_API.Models;

namespace f7Race_API.Custom
{
    public class Utilities
    {
        private readonly string jwtsecret;
        public Utilities(string jwtSecret)
        {
            DotEnv.Load();
            jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? string.Empty;
            jwtsecret = jwtSecret;
        }

        public string CrpytSHA256(string text){

            using(SHA256 sha256Hash = SHA256.Create()){
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++){
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }

        }

        public string GenerateJWTToken(User user){

            // create info of user for the token

            var userClaim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsecret));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: userClaim,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}