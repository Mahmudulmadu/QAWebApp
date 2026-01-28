using QA.Domain.Models;

namespace QA.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<ApplicationUser>
{
    Task<ApplicationUser?> GetByUsernameAsync(string username);
    Task<ApplicationUser?> GetByEmailAsync(string email);
    Task<ApplicationUser?> GetByUsernameOrEmailAsync(string value);
}
