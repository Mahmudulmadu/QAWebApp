using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;
public interface IQuestionService
{
    Task<(bool Success, string Message, Question? Question)> CreateQuestionAsync(QuestionCreateDto dto, int userId);
    Task<(bool Success, string Message)> UpdateQuestionAsync(int questionId, QuestionUpdateDto dto, int userId);
    Task<(bool Success, string Message)> DeleteQuestionAsync(int questionId, int userId);
    Task<Question?> GetQuestionByIdAsync(int questionId);
    Task<List<Question>> GetAllQuestionsAsync(string? searchTerm = null, string? tag = null);
    Task<List<Question>> GetLatestQuestionsAsync(int count = 10);
    Task IncrementViewCountAsync(int questionId);
}
