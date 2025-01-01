using Microsoft.EntityFrameworkCore;
using RealPOSApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString =
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDb>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
// The following three options help with debugging, but should
// be changed or removed for production.
.LogTo(Console.WriteLine, LogLevel.Information)
.EnableSensitiveDataLogging()
.EnableDetailedErrors());
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();