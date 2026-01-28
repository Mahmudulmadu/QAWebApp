using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Repositories;

public interface IQuestionRepository : IGenericRepository<Question>
{
    Task<Question?> GetWithDetailsAsync(int id);
    Task<List<Question>> GetLatestAsync(int count);
    IQueryable<Question> Query();
}

