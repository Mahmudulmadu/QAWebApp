using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;

public interface IVoteService
{
    Task<(bool Success, string Message)> VoteAsync(VoteDto dto, int userId);
    Task<int> GetVoteCountAsync(int? questionId, int? answerId);
    Task<bool> HasUserVotedAsync(int userId, int? questionId, int? answerId);
}
