using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teach.Dto_s;
using Teach.Entities;
using Teach.ExtensionFunctions;
using Teach.Services.JWTService;

namespace Teach.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<User> _userManager;

    public AuthController(IAuthService authService, UserManager<User> userManager)
    {
        _userManager = userManager;
        _authService = authService;
    }

    [HttpGet,Authorize]
    public ActionResult<string> GetMyName() => Ok(CreateTokenInJwtAuthorizationFromUsers.GetMyId());

    [HttpGet("ListUsers"), Authorize]
    public async Task<IActionResult> GetAllUsers()
    {
          return Ok(await _authService.GetAllUsers());
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UsersDto request) => Ok(await _authService.Register(request));

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsersDto request) => Ok(await _authService.Login(request));
}