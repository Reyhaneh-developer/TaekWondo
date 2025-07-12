using api.Interfaces;
using api.Repositorys;
using api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.services.AddApplicationService(builder.configuration);
builder.services.AddRepositoryService();
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication(); 

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();