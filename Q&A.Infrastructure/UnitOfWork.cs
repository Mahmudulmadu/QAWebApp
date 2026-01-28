using Q_A.Application.Interfaces;
using QA.Application.Interfaces.Repositories;
using QA.Infrastructure.Data;
using QA.Infrastructure.Repositories;

namespace QA.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IQuestionRepository Questions { get; }
    public IAnswerRepository Answers { get; }
    public ICommentRepository Comments { get; }
    public ITagRepository Tags { get; }
    public IVoteRepository Votes { get; }
    public IUserRepository Users { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Questions = new QuestionRepository(context);
        Answers = new AnswerRepository(context);
        Comments = new CommentRepository(context);
        Tags = new TagRepository(context);
        Votes = new VoteRepository(context);
        Users = new UserRepository(context);
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public void Dispose()
        => _context.Dispose();
}
