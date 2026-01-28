using QA.Application.DTOs;
using QA.Domain.Models;

namespace QA.Application.Interfaces.Services;

public interface ITagService
{
    Task<List<Tag>> GetOrCreateTagsAsync(string tagsString);
    Task<List<Tag>> GetAllTagsAsync();
    Task<List<Tag>> GetPopularTagsAsync(int count = 10);
}
