using Microsoft.IdentityModel.Tokens; // SymmetricSecurityKey
using System.IdentityModel.Tokens.Jwt; // JwtRegisteredClaimNames
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TripInfo.API.DbContexts;
using TripInfo.API.Entities;

namespace TripInfo.API.ManagerClasses;

public class SecurityManager
{
    public SecurityManager(TripInfoContext context,
                           UserAuthBase auth,
                           JwtSettings settings)
    {
        _DbContext = context;
        _auth = auth;
        _settings = settings;
    }

    private TripInfoContext _DbContext = null;
    private UserAuthBase _auth = null;
    private JwtSettings _settings = null;

    //return a list of user claims 
    protected List<UserClaim> GetUserClaims(Guid userId) 
    {
        List<UserClaim> list = new List<UserClaim>();

        try
        {
            list = _DbContext.Claims.Where(u => u.UserId == userId).ToList(); 
        } catch (Exception ex)
        {
            throw new Exception(
                "Exception trying to retrieve user claims.", ex );
        }

        return list;
    }

    protected string BuildJwtToken(IList<UserClaim> claims, string userName) {
        // Build the SymmetricSecurityKey
        SymmetricSecurityKey key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_settings.Key));

        // Create standard JWT claims
        List<Claim> jwtClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName), // JwtRegisteredClaimNames has an enumeration
            new Claim(JwtRegisteredClaimNames.Jti,
                      Guid.NewGuid().ToString())
        };

        // Add custom claims
        foreach (UserClaim claim in claims)
        {
            jwtClaims.Add(new Claim(claim.ClaimType,
                                    claim.ClaimValue)); 
        }

        // Create the JwtSecurity object 
        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims:  jwtClaims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(
                    _settings.MinutesToExpiration),
            signingCredentials: new SigningCredentials(key,
                            SecurityAlgorithms.HmacSha256)
        );
        // Create a string representation of the Jwt Token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /*
     * Reflection is a C# technique whereby you set properties at runtime based on string data instead of compile-time code.
     */
    protected UserAuthBase BuildUserAuthObject(Guid userId, string userName) {
        List<UserClaim> claims = new List<UserClaim>();
        Type _authType = _auth.GetType(); // use reflection to get actual type

        // Set User Properties 
        _auth.UserId = userId;
        _auth.UserName = userName;
        _auth.IsAuthenticated = true;

        // Get all claims for this user
        claims = GetUserClaims(userId);

        // Loop through all claims and 
        // set properties of user object 
        foreach (UserClaim claim in claims)
        {
            try
            {
                // Use reflection to get property
                var property = _authType.GetProperty(claim.ClaimType);
                if (property != null) // This code will prevent the NullReferenceException by ensuring that SetValue is only called when the property exists
                {
                    // Set property value
                    property.SetValue(_auth, Convert.ToBoolean(claim.ClaimValue), null);
                }
                else
                {
                    // Log error or handle case where property is not found
                    Console.WriteLine($"Property '{claim.ClaimType}' not found on type '{_authType.Name}'."); // If the property does not exist, it logs an error message
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error setting property value: {ex.Message}");
            }
        }

        // Create JWT Bearer Token
        _auth.BearerToken = BuildJwtToken(claims, userName);
        return _auth;
    }

    // public method called from our security controller , return our user auth based class 
    public UserAuthBase ValidateUser(string userName, string password)
    {
        List<UserBase> list = new List<UserBase>();

        try
        {
            list = _DbContext.Users.Where(
                u => u.UserName.ToLower() == userName.ToLower()
                && u.Password.ToLower() ==
                    password.ToLower()).ToList();

            if (list.Count() > 0)
            {
                _auth = BuildUserAuthObject(list[0].UserId, userName);
            }
        } catch (Exception ex)
        {
            throw new Exception(
                "Exception while trying to retrieve user.", ex );
        }

        return _auth;
    }

}
