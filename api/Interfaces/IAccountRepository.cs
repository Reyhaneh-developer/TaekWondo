using api.DTOs;
using api.Models;
using MongoDB.Driver;

namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggedInDto?> RegisterAsync(AppUser UserInput, CancellationToken cancellationToken);
    public Task<LoggedInDto?> LoginAsync(LoginDto UserInput, CancellationToken cancellationToken);
    public Task<List<AppUser>?> GetAllSynce(CancellationToken cancellationToken);
    public Task<LoggedInDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken);
    public Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken);
}
