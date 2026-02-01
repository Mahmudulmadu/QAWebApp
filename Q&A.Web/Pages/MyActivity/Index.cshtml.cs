using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using System.Security.Claims;

namespace QA.Web.Pages.MyActivity;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IAnswerService _answerService;

    public IndexModel(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    public List<MyAnswerDto> Answers { get; set; } = new();

    public async Task OnGetAsync()
    {
        var userId = int.Parse(
            User.Claims.First(c =>
                c.Type == ClaimTypes.NameIdentifier || c.Type == "id"
            ).Value
        );

        Answers = await _answerService.GetMyAnswersAsync(userId);
    }
}
