using QA.Domain.Models;

namespace QA.Application.Interfaces.Repositories;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<List<Comment>> GetByQuestionIdAsync(int questionId);
    Task<List<Comment>> GetByAnswerIdAsync(int answerId);
}
