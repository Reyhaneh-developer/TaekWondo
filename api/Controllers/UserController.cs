using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class UserController(IUserRepository userRepository) : BaseApiController
{
    [HttpPut("update/{userId}")]
    public async Task<ActionResult<LoggedInDto>> UpdatById(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? loggedInDto = await MemberRepository.UpdateByIdAsync(userId, userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("Operation failed");

        return loggedInDto;
    }
}
