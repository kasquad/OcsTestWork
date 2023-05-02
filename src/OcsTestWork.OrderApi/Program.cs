using OcsTestWork.OrderApi.Infrastructure.Extensions;
using OcsTestWork.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddHttp();
// Add services to the container.
builder.Services.AddPersistence();
builder.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();