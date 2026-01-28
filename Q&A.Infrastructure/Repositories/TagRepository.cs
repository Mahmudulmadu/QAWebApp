using Microsoft.EntityFrameworkCore;
using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;
using QA.Infrastructure.Data;

namespace QA.Infrastructure.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Tag?> GetByNameAsync(string name)
    {
        return await _context.Tags
            .FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<List<Tag>> GetPopularTagsAsync(int count)
    {
        return await _context.Tags
            .Include(t => t.Questions)
            .OrderByDescending(t => t.Questions.Count)
            .Take(count)
            .ToListAsync();
    }
}
