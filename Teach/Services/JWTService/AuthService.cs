using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teach.Data;
using Teach.Dto_s;
using Teach.Entities;
using Teach.ExtensionFunctions;
using BCryptNet = BCrypt.Net;

namespace Teach.Services.JWTService;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<User> Register(UsersDto request)
    {
        var user = new User
        {
            UserName = request.Name,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception("Password isn't hashed");
        }


        await _userManager.AddToRoleAsync(user, Enum.GetName(request.Role).ToUpper());
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<string> Login(UsersDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, roleClaims);
            return token;
        }

        throw new BadHttpRequestException("User not found.");
    }

    public async Task<List<User>> GetAllUsers() => await _context.Users.ToListAsync();
}