using InterviewServer.DAO.Providers;
using InterviewServer.DAO.Providers.DB;
using InterviewServer.DAO.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<IUsersProvider, UsersProvider>();
builder.Services.AddDbContextPool<UsersContext>(opt =>
{
    opt.UseSqlite("Data Source=users.db3");
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
