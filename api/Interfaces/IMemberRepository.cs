namespace api.Interfaces;

public interface IMemberRepository
{
    public Task<List<AppUser>?> GetAllAsynce(CancellationToken cancellationToken);
}
