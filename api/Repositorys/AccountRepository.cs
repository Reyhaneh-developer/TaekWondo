using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Repositorys;

public class AccountRepository : IAccountRepository
{
    private readonly IMongoCollection<AppUser> _collection;

    // Dependency Injection
    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }

    public async Task<LoggedInDto?> RegisterAsync(AppUser UserInput, CancellationToken cancellationToken)
    {
        AppUser user = await _collection.Find<AppUser>(doc => doc.Email == UserInput.Email).FirstOrDefaultAsync(cancellationToken);

        if (user is not null)
            return null;

        await _collection.InsertOneAsync(UserInput, null, cancellationToken);

        LoggedInDto loggedInDto = new(
            Email: UserInput.Email,
            Name: UserInput.Name
        );

        return loggedInDto;
    }

    public async Task<LoggedInDto?> LoginAsync(LoginDto UserInput, CancellationToken cancellationToken)
    {
        AppUser user =
        await _collection.Find(doc => doc.Email == UserInput.Email && doc.Password == UserInput.Password).FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return null;

        LoggedInDto loggedInDto = new(
            Email: user.Email,
            Name: user.Name
        );

        return loggedInDto;
    }



    public async Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        return await _collection.DeleteOneAsync<AppUser>(doc => doc.Id == userId, cancellationToken);
    }
}
