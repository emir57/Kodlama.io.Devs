using Kodlama.io.devs.Application.Features.GitHubs.Commands.CreateGitHub;
using Kodlama.io.devs.Application.Features.GitHubs.Commands.DeleteGitHub;
using Kodlama.io.devs.Application.Features.GitHubs.Commands.UpdateGitHub;
using Kodlama.io.devs.Application.Features.GitHubs.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GitHubsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateGitHubCommand createGitHubCommand)
    {
        CreatedGitHubDto result = await Mediator.Send(createGitHubCommand);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateGitHubCommand updateGitHubCommand)
    {
        UpdatedGitHubDto result = await Mediator.Send(updateGitHubCommand);
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteGitHubCommand deleteGitHubCommand)
    {
        DeletedGitHubDto result = await Mediator.Send(deleteGitHubCommand);
        return Ok(result);
    }
}
