using Microsoft.EntityFrameworkCore;
using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;
using QA.Infrastructure.Data;

namespace QA.Infrastructure.Repositories;

public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
{
    public AnswerRepository(ApplicationDbContext context) : base(context) { }

    public async Task<List<Answer>> GetByQuestionIdAsync(int questionId)
    {
        return await _context.Answers
            .Include(a => a.User)
            .Where(a => a.QuestionId == questionId)
            .OrderByDescending(a => a.IsAccepted)
            .ThenByDescending(a => a.VoteCount)
            .ToListAsync();
    }
    public async Task<List<Answer>> GetByUserIdWithQuestionAsync(int userId)
    {
        return await _context.Answers
            .Include(a => a.Question)   // include question to avoid null
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }


    public async Task<Answer?> GetWithQuestionAsync(int answerId)
    {
        return await _context.Answers
            .Include(a => a.Question)
            .FirstOrDefaultAsync(a => a.Id == answerId);
    }
}
