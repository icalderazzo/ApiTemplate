using Core.Interfaces.Infrastructure.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using DapperDatabaseInterface;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database config
builder.Services.AddScoped<IDbContext>(c => ContextBuilder.Build(builder.Configuration.GetConnectionString("Testing")));

//Container config
#region Repositories
builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();
#endregion
#region Services
builder.Services.AddTransient<IWorkoutService, WorkoutService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
