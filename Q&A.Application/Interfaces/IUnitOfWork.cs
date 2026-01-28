using QA.Application.Interfaces.Repositories;
using QA.Domain.Models;

namespace Q_A.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IQuestionRepository Questions { get; }
    IAnswerRepository Answers { get; }
    ICommentRepository Comments { get; }

    ITagRepository Tags { get; }
    IVoteRepository Votes { get; }

    IUserRepository Users { get; }

    Task<int> SaveChangesAsync();
}

