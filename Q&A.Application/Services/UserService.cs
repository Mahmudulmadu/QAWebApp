using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;
using Q_A.Application.Interfaces;
using Microsoft.Extensions.Logging;
using BCrypt.Net;

namespace QA.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;

    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<(bool Success, string Message, ApplicationUser? User)> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _unitOfWork.Users
            .GetByUsernameOrEmailAsync(dto.Username);

        if (existingUser != null)
            return (false, "Username or email already exists", null);

        var user = new ApplicationUser
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Registration successful", user);
    }

    public async Task<(bool Success, string Message, ApplicationUser? User)> LoginAsync(LoginDto dto)
    {
        var user = await _unitOfWork.Users
            .GetByUsernameOrEmailAsync(dto.UsernameOrEmail);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return (false, "Invalid credentials", null);

        return (true, "Login successful", user);
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(int userId)
        => await _unitOfWork.Users.GetByIdAsync(userId);

    public async Task<ApplicationUser?> GetUserByUsernameAsync(string username)
        => await _unitOfWork.Users.GetByUsernameAsync(username);
}
