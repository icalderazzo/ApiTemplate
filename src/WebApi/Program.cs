using Serilog;
using AutoMapper;
using WebApi.Extensions.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Default api config
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database config
builder.Services.AddDapperDatabaseInterface(
    connectionString: builder.Configuration.GetConnectionString("Testing")
);

// Core services and repositories
builder.Services.AddCoreServices();
builder.Services.AddRepositories();

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