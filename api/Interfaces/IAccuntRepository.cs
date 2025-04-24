using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;
using MongoDB.Driver;

namespace api.Interfaces;

public interface IAccuntRepository
{
    public Task<LoggedInDto?> RegisterAsync(AppUser UserInput, CancellationToken cancellationToken);
    public Task<LoggedInDto?> LoginAsynce(AppUser UserInput, CancellationToken cancellationToken);
    public Task<List<AppUser>?> GetAllSynce (CancellationToken cancellationToken);
    public Task<LoggedInDto?> UpdateByIdAsynce (string userid, AppUser userInput,CancellationToken cancellationToken);
    public Task<DeleteResult?> DeleteByIdAsynce (string userId, CancellationToken cancellationToken);




}
