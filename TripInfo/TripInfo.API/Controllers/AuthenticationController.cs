using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; // ApiController, ActionResult, ControllerBase, Route
using Microsoft.IdentityModel.Tokens; // SymmetricSecurityKey
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt; // JwtSecurityToken
using System.Security.Claims; // Claim
using System.Text; // Encoding 

namespace TripInfo.API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    // We won't use this outside of this class, so we can scope it to this namespace.
    // Tt will automatically be deserialized from the request body as a class is a complex object.
    public class  AuthenticationRequestBody
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    private class TripInfoUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; } 

        public TripInfoUser(
            int userId, 
            string userName, 
            string firstName, 
            string lastName, 
            string cityName)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            City = cityName;
        }
    }

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration ?? 
            throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(
        AuthenticationRequestBody authenticationRequestBody)
    {
        // Step 1: validate the username/password
        var user = ValidateUserCredentials(
            authenticationRequestBody.UserName,
            authenticationRequestBody.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        // Step 2: create a token (JWT)
        var securityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])); //5:35
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        // key values pairs we call claims
        // The claims that we want to include in the token
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
        claimsForToken.Add(new Claim("given_name", user.FirstName));
        claimsForToken.Add(new Claim("family_name", user.LastName));
        claimsForToken.Add(new Claim("city", user.City)); // do i need this. he uses city names, not unique. 

        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow, // INDICATES THE START OF TOKEN VALIDITY
            // In between this time, the token is valid. 
            DateTime.UtcNow.AddHours(1), // INDICATES THE END OF TOKEN VALIDITY
            signingCredentials);

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        return Ok(tokenToReturn); 
    }

    private TripInfoUser ValidateUserCredentials(string? userName, string? password)
    {
        // We don't have a user database or table. If you have, check the passed-through
        // username/password against what''s stored in the database.
        //
        // For demo purposes, we assume the vredentials are valid

        // return a new TripInfoUser (valuess would normally come from your user DB/table)

        return new TripInfoUser(
            1,
            userName ?? "",
            "Daniel",
            "Herrera",
            "San Diego" // why can't i get "http://localhost:{{portNumber}}/api/trips/1/customers" to work
            );
    }
}
