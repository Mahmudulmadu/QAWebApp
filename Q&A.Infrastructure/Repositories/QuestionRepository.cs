using Microsoft.EntityFrameworkCore;
using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;
using QA.Infrastructure.Data;

namespace QA.Infrastructure.Repositories;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    public QuestionRepository(ApplicationDbContext context) : base(context) { }

    public IQueryable<Question> Query() => _context.Questions.AsQueryable();

    public async Task<Question?> GetWithDetailsAsync(int id)
    {
        return await _context.Questions
            .Include(q => q.User)
            .Include(q => q.Tags)
            .Include(q => q.Answers)
                .ThenInclude(a => a.User)
            .Include(q => q.Comments)
                .ThenInclude(c => c.User)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<Question>> GetLatestAsync(int count)
    {
        return await _context.Questions
            .Include(q => q.User)
            .Include(q => q.Tags)
            .OrderByDescending(q => q.CreatedAt)
            .Take(count)
            .ToListAsync();
    }
}

