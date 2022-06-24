using InterviewServer.DAO.Entities;
using InterviewServer.DAO.Providers;
using InterviewServer.DAO.Providers.DB;
using InterviewServer.DAO.Providers.Interfaces;
using InterviewServer.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<IUsersProvider, UsersProvider>();
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher>();
builder.Services.AddDbContextPool<UsersContext>(opt =>
{
    opt.UseSqlite("Data Source=users.db3");
});
builder.Services.AddAutoMapper();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
