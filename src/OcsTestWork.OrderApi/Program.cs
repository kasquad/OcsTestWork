using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using OcsTestWork.OrderApi.Infrastructure.Extensions;
using OcsTestWork.Persistence;
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


// Очень плохо, но я не успел сделать лучше..
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DefaultPostgresConnectionString"),            
    x =>
        x.MigrationsAssembly("OcsTestWork.Migrator"));

var context=  new AppDbContext(optionsBuilder.Options);
var migrator = context.Database.GetService<IMigrator>();
await migrator.MigrateAsync();

app.Run();