using QA.Domain.Models;

namespace QA.Application.Interfaces.Repositories;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetByNameAsync(string name);
    Task<List<Tag>> GetPopularTagsAsync(int count);
}
