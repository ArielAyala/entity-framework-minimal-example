using entity_framework_minimal_example;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EfMainContext>(p=> p.UseInMemoryDatabase("EFMinimalExampleDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] EfMainContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database created in memory " + dbContext.Database.IsInMemory());
});

app.Run();
