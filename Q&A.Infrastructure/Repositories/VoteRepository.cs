using Microsoft.EntityFrameworkCore;
using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;
using QA.Infrastructure.Data;

namespace QA.Infrastructure.Repositories;

public class VoteRepository : GenericRepository<Vote>, IVoteRepository
{
    public VoteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Vote?> GetUserVoteAsync(int userId, int? questionId, int? answerId)
    {
        return await _context.Votes.FirstOrDefaultAsync(v =>
            v.UserId == userId &&
            v.QuestionId == questionId &&
            v.AnswerId == answerId);
    }

    public async Task<bool> HasUserVotedAsync(int userId, int? questionId, int? answerId)
    {
        return await _context.Votes.AnyAsync(v =>
            v.UserId == userId &&
            v.QuestionId == questionId &&
            v.AnswerId == answerId);
    }
}
