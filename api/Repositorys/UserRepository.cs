namespace api.Repositorys;

public class UserRepository : IUserRepository
{
      private readonly IMongoCollection<AppUser> _collection;
    private readonly ITokenService _tokenService;

    // Dependency Injection
    public UserRepository(IMongoClient client, IMongoDbSettings dbSettings, ITokenService tokenService)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");

        _tokenService = tokenService;
    }

    public async Task<LoggedInDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        UpdateDefinition<AppUser> updateDef = Builders<AppUser>.Update
        .Set(user => user.Email, userInput.Email.Trim().ToLower());

        await _collection.UpdateOneAsync(user => user.Id == userId, updateDef, null, cancellationToken);

        AppUser appUser = await _collection.Find(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

   
        string? token = _tokenService.CreateToken(appUser);

        return Mappers.ConvertAppUserToLoggedInDto(appUser, token);
    }
}
