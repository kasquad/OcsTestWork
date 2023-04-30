using OcsTestWork.OrderApi.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddHttp();

builder.Services.AddEndpointsApiExplorer();
builder.AddInfrastructure();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

