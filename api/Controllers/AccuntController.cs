using api.DTOs;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AccountController(IAccountRepository accountRepository) : BaseApiController
{ 
    [HttpPost("register")]
       public async Task<ActionResult<LoggedInDto>> Register(AppUser userInput, CancellationToken cancellationToken)

    {
        if (userInput.Password != userInput.ConfirmPassword)
            return BadRequest("Your password do not match!");

        LoggedInDto? loggedInDto = await accountRepository.RegisterAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("This email is already taken");

        return Ok(loggedInDto);
    }
}
