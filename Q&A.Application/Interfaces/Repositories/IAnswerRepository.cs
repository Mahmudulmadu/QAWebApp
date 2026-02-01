using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Repositories;

public interface IAnswerRepository : IGenericRepository<Answer>
{
    Task<List<Answer>> GetByQuestionIdAsync(int questionId);
    Task<Answer?> GetWithQuestionAsync(int answerId);
    Task<List<Answer>> GetByUserIdWithQuestionAsync(int userId);
}
