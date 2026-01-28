using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;

public interface IAnswerService
{
    Task<(bool Success, string Message, Answer? Answer)> CreateAnswerAsync(AnswerCreateDto dto, int userId);
    Task<(bool Success, string Message)> UpdateAnswerAsync(int answerId, AnswerUpdateDto dto, int userId);
    Task<(bool Success, string Message)> DeleteAnswerAsync(int answerId, int userId);
    Task<(bool Success, string Message)> AcceptAnswerAsync(int answerId, int userId);
    Task<Answer?> GetAnswerByIdAsync(int answerId);
    Task<List<Answer>> GetAnswersByQuestionIdAsync(int questionId);
}
