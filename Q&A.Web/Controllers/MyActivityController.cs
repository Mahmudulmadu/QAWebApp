using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QA.Application.Interfaces.Services;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MyActivityController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public MyActivityController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    [HttpGet("answers")]
    public async Task<IActionResult> MyAnswers()
    {
        var userIdClaim =
            User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue("id");

        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized("User id claim missing");

        if (!int.TryParse(userIdClaim, out var userId))
            return Unauthorized("Invalid user id");

        var answers = await _answerService.GetMyAnswersAsync(userId);
        return Ok(answers);
    }

}
