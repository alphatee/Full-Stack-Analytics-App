using Microsoft.AspNetCore.Mvc;
using TripInfo.API.DbContexts;
using TripInfo.API.Entities;
using TripInfo.API.ManagerClasses;

namespace TripInfo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    public SecurityController(ILogger<SecurityController> logger,
                              TripInfoContext context,
                              JwtSettings settings)
    {
        _logger = logger;
        _DbContext = context;
        _settings = settings;
    }

    private readonly ILogger<SecurityController> _logger;
    private readonly TripInfoContext _DbContext;
    private readonly JwtSettings _settings;

    [HttpPost("Login")]
    public IActionResult Login([FromBody] AppUser user) // pass in the AppUser
    {
        IActionResult ret = null;  
        AppUserAuth auth = new AppUserAuth(); // pass in concrete instance that has boolean properties
        SecurityManager mgr = new SecurityManager(
            _DbContext, auth, _settings);

        auth = (AppUserAuth)mgr.ValidateUser(user.UserName, user.Password);
        if (auth.IsAuthenticated)
        {
            ret = StatusCode(StatusCodes.Status200OK, auth); // our payload is that auth object once authenticated
        } else
        {
            ret = StatusCode(StatusCodes.Status404NotFound,
                             "Invalid User Name/Password");
        }

        return ret;
    }
}
