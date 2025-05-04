using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces;

public interface IMemberRepository
{
    public Task<List<AppUser>?> GetAllSynce(CancellationToken cancellationToken);

}
