using entity_framework_minimal_example;
using entity_framework_minimal_example.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<EfMainContext>(p=> p.UseInMemoryDatabase("EFMinimalExampleDB"));
builder.Services.AddSqlServer<EfMainContext>(builder.Configuration.GetConnectionString("EfMinimalExampleConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] EfMainContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database created in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] EfMainContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include( x => x.Category));
});

app.MapGet("/api/task/{taskId}", async ([FromServices] EfMainContext dbContext, Guid taskId) =>
{
    return Results.Ok(dbContext.Tasks.Include( x => x.Category).Where(x => x.TaskId == taskId));
});





app.Run();
