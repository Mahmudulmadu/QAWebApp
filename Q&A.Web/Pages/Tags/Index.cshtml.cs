using Microsoft.AspNetCore.Mvc.RazorPages;
using QA.Domain.Models;
using QA.Application.Interfaces.Services;

namespace QA.Web.Pages.Tags;

public class TagsIndexModel : PageModel
{
    private readonly ITagService _tagService;

    public TagsIndexModel(ITagService tagService)
    {
        _tagService = tagService;
    }

    public List<Tag> Tags { get; set; } = new();

    public async Task OnGetAsync()
    {
        Tags = await _tagService.GetPopularTagsAsync(50);
    }
}
