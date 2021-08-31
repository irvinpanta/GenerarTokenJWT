using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenJWT.Entity;
using TokenJWT.Security;
using TokenJWT.Services;

namespace TokenJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        public TokenController(IConfiguration configuration,
                                ISecurityService securityService)
        {
            _configuration = configuration;
            _securityService = securityService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin userLogin)
        {
            var validation = await IsValidaUser(userLogin);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return BadRequest();
        }

        private async Task<(bool, Empleado)> IsValidaUser(UserLogin userLogin)
        {
            var response = await _securityService.GetUserCredentials(userLogin);            

            return (response != null, response);
        }

        private string GenerateToken(Empleado security)
        {

            var symmetricSecurityKry = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Secretkey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKry, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, $"{security.Nombres} {security.Apellidos}"),
                new Claim("Email", "irvinpanta96@gmail.com"),
                new Claim(ClaimTypes.Role, security.Roles.Descripcion),
            };

            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
