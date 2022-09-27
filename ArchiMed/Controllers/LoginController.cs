using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArchiMed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace ArchiMed.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly ArchiMedDB _context;

    public LoginController(ArchiMedDB context)
    {
        _context = context;
    }

    public class Response
    {
        public string token { get; set; }
        public string role { get; set; }
        
        public int userId { get; set; }

        public Response(string token, string role, int userId)
        {
            this.token = token;
            this.role = role;
            this.userId = userId;
        }
    }
    
        [HttpPost]
     public async Task<ActionResult<Response>>  Login(UserLogin user)
    {
    
    if (string.IsNullOrEmpty(user.email) ||
        string.IsNullOrEmpty(user.password)) return BadRequest("Email or Password Not provided");

    var loggedInUser =_context.Users.FirstOrDefault(o =>
            o.email.Equals(user.email) &&
            o.password.Equals(user.password)); 
    if (loggedInUser is null) return NotFound("User Not Found");

    var claims = new[]
    {
        new Claim(ClaimTypes.Email, loggedInUser.email),
        new Claim(ClaimTypes.GivenName, loggedInUser.fisrtName),
        new Claim(ClaimTypes.Surname, loggedInUser.lastName),
        new Claim(ClaimTypes.Role, loggedInUser.GetType().Name)
    };
    
    var key = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Key"];

    var token = new JwtSecurityToken
    (
        claims: claims,
        expires: DateTime.UtcNow.AddDays(60),
        notBefore: DateTime.UtcNow,
        signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256)
    );

    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

    return new Response(tokenString,loggedInUser.GetType().Name, loggedInUser.id);
}
}

