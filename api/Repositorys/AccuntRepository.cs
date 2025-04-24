using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Settings;
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
        
    }

    public Task<LoggedInDto?> LoginAsynce(AppUser UserInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task<List<AppUser>?> GetAllSynce(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<LoggedInDto?> UpdateByIdAsynce(string userid, AppUser userInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<DeleteResult?> DeleteByIdAsynce(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
