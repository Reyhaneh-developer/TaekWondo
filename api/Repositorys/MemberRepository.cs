using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Repositorys;

public class MemberRepository : IMemberRepository
{
    private readonly IMongoCollection<AppUser> _collection;

    // Dependency Injection
    public MemberRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }

    internal static async Task<LoggedInDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AppUser>?> GetAllSynce(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);

        if (appUsers.Count == 0)
            return null;

        return appUsers;
    }

}
