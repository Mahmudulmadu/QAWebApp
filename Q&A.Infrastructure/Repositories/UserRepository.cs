using Microsoft.EntityFrameworkCore;
using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;
using QA.Infrastructure.Data;

namespace QA.Infrastructure.Repositories;

public class UserRepository
    : GenericRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ApplicationUser?> GetByUsernameAsync(string username)
        => await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<ApplicationUser?> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<ApplicationUser?> GetByUsernameOrEmailAsync(string value)
        => await _context.Users.FirstOrDefaultAsync(
            u => u.Username == value || u.Email == value);
}
