using Application;
using Application.Repositories;
using Infrastructure.SQLServer;
using Infrastructure.SQLServer.Repositories;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string db = builder.Configuration["Database:ConnectionString"];
SeedData.InitSeedData(db);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped((serviceProvider) =>
{
    return new DbContext(db);
});
builder.Services.AddApplicationDependencies();

builder.Services.AddScoped<IRecordRepository, RecordRepository>();


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
