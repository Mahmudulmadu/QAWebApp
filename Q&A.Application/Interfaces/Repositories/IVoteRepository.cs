using QA.Domain.Models;

namespace QA.Application.Interfaces.Repositories;

public interface IVoteRepository : IGenericRepository<Vote>
{
    Task<Vote?> GetUserVoteAsync(int userId, int? questionId, int? answerId);
    Task<bool> HasUserVotedAsync(int userId, int? questionId, int? answerId);
}
