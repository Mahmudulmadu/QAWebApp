using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(ApplicationUser user);
    int? ValidateToken(string token);
}
