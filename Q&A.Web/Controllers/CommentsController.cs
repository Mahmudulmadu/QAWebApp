using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q_A.Application.DTOs;
using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using System.Security.Claims;

namespace QA.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly ILogger<CommentsController> _logger;

    public CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
    {
        _commentService = commentService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized();
        }

        var userId = int.Parse(userIdClaim);
        var result = await _commentService.CreateCommentAsync(dto, userId);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return Ok(new { message = result.Message, commentId = result.Comment!.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CommentUpdateDto dto)
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var (success, _) =
            await _commentService.UpdateCommentAsync(id, dto, userId);

        if (!success) return Forbid();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var (success, _) =
            await _commentService.DeleteCommentAsync(id, userId);

        if (!success) return Forbid();
        return Ok();
    }
}
