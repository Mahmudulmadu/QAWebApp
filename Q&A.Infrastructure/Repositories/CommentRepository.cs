using Microsoft.EntityFrameworkCore;
using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;
using QA.Infrastructure.Data;

namespace QA.Infrastructure.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<List<Comment>> GetByQuestionIdAsync(int questionId)
    {
        return await _context.Comments
            .Include(c => c.User)
            .Where(c => c.QuestionId == questionId)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Comment>> GetByAnswerIdAsync(int answerId)
    {
        return await _context.Comments
            .Include(c => c.User)
            .Where(c => c.AnswerId == answerId)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();
    }
}
