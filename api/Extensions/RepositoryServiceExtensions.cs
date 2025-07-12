using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Extensions;

public static class RepositoryServiceExtensions
{
    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<IUserRepository,UserRepository>();
        builder.Services.AddScoped<IMemberRepository,MemberRepository>();

        return services;
    }
}
