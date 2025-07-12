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

    public async Task<List<AppUser>?> GetAllAsynce(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);

        if (appUsers.Count == 0)
            return null;

        return appUsers;
    }
}

