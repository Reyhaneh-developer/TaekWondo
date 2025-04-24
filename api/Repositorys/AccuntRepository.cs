using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Repositorys;

public class AccuntRepository : IAccuntRepository
{
    private readonly IMongoCollection<AppUser> _collection;

    // Dependency Injection
    public AccuntRepository(IMongoClient client, IMongoDbSettings dbSettings)
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

    public async Task<LoggedInDto?> LoginAsynce(AppUser UserInput, CancellationToken cancellationToken)
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

    public async Task<List<AppUser>?> GetAllSynce(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);

        if (appUsers.Count == 0)
            return null;

        return appUsers;
    }

    public async Task<LoggedInDto?> UpdateByIdAsynce(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        UpdateDefinition<AppUser> updateDef = Builders<AppUser>.Update
        .Set(user => user.Email, userInput.Email.Trim().ToLower());

        await _collection.UpdateOneAsync(user => user.Id == userId, updateDef, null, cancellationToken);

        AppUser appUser = await _collection.Find(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        LoggedInDto loggedInDto = new(
            Email: appUser.Email,
            Name: appUser.Name
        );

        return loggedInDto;
    }

    public async Task<DeleteResult?> DeleteByIdAsynce(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        return await _collection.DeleteOneAsync<AppUser>(doc => doc.Id == userId, cancellationToken);
    }
}
