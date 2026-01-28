using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;
public interface IUserService
{
    Task<(bool Success, string Message, ApplicationUser? User)> RegisterAsync(RegisterDto dto);
    Task<(bool Success, string Message, ApplicationUser? User)> LoginAsync(LoginDto dto);
    Task<ApplicationUser?> GetUserByIdAsync(int userId);
    Task<ApplicationUser?> GetUserByUsernameAsync(string username);
}
