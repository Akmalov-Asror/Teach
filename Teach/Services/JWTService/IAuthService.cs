using Teach.Dto_s;
using Teach.Entities;

namespace Teach.Services.JWTService;

public interface IAuthService
{
    Task<User> Register(UsersDto userDto);
    Task<string> Login(UsersDto userDto);
    Task<List<User>> GetAllUsers();
}