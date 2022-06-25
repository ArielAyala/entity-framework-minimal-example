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
    return Results.Ok(dbContext.Tasks.Include(x => x.Category));
});

app.MapGet("/api/task/{taskId}", async ([FromServices] EfMainContext dbContext, Guid taskId) =>
{
    return Results.Ok(dbContext.Tasks.Include(x => x.Category).Where(x => x.TaskId == taskId));
});

app.MapPost("/api/tasks", async ([FromServices] EfMainContext dbContext, [FromBody] TaskModel task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreateDate = DateTime.Now;
    await dbContext.AddAsync(task);
    //await dbContext.Tasks.AddAsync(task);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tasks/{taskId}", async ([FromServices] EfMainContext dbContext, [FromBody] TaskModel task, [FromRoute] Guid taskid) =>
{
    var taskFound = dbContext.Tasks.Find(taskid);
    if (taskFound != null)
    {
        taskFound.CategoryId = task.CategoryId;
        taskFound.Title = task.Title;
        taskFound.TaskPriority = task.TaskPriority;
        taskFound.Description = task.Description;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }


    return Results.NotFound();
});





app.Run();
