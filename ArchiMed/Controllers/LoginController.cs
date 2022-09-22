using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArchiMed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    
    
        [HttpPost]
     public async Task<ActionResult<String>>  Login(UserLogin luser)
    {
    
    if (string.IsNullOrEmpty(luser.email) ||
        string.IsNullOrEmpty(luser.password)) return "Invalid user credentials";
    
    var loggedInUser =_context.Users.FirstOrDefault(o =>
            o.email.Equals(luser.email) &&
            o.password.Equals(luser.password)); 
    if (loggedInUser is null) return "User not found";

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

    return tokenString;
}
}