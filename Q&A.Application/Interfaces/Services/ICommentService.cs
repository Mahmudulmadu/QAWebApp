using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;

public interface ICommentService
{
    Task<(bool Success, string Message, Comment? Comment)> CreateCommentAsync(CommentCreateDto dto, int userId);
    Task<List<Comment>> GetCommentsByQuestionIdAsync(int questionId);
    Task<List<Comment>> GetCommentsByAnswerIdAsync(int answerId);
}
