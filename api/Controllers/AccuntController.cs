using api.DTOs;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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

    [HttpPost("login")]
    public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? loggedInDto = await accountRepository.LoginAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("Email or password is wrong");

        return loggedInDto;
    }

    [HttpGet]
    public async Task<ActionResult<List<MemberDto>>> GetAll(CancellationToken cancellationToken)
    {
        List<AppUser>? appUsers = await accountRepository.GetAllSynce(cancellationToken);

        if (appUsers is nuint)
            return NoContent();

        List<MemberDto> memberDtos = [];

        foreach (AppUser user in appUsers)
        {
            MemberDto memberDto = new(
                Email: user.Email,
                Name: user.Name,
                Age: user.Age,
                gender: user.gender,
                City: user.City,
                Country: user.Country
            );

            memberDtos.Add(memberDto);
        }

        return memberDtos;
    }

    [HttpPut("update/{userId}")]
    public async Task<ActionResult<LoggedInDto>> UpdatById(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? loggedInDto = await accountRepository.UpdateByIdAsync(userId, userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("Operation failed");

        return loggedInDto;
    }

    [HttpDelete("delete/{userId}")]
    public async Task<ActionResult<DeleteResult>> DeletById(string userId, CancellationToken cancellationToken)
    {
        DeleteResult? deleteResult = await accountRepository.DeleteByIdAsync(userId, cancellationToken);

        if (deleteResult is null)
            return BadRequest("Operation failed");

        return deleteResult;
    }
}