using Microsoft.EntityFrameworkCore;
using Utopia.Infrastructure.Data;
using Utopia.Api.Requests;
using Utopia.Domain.Entities;
//using Microsoft.OpenApi.Models;
using TaskStatus = Utopia.Domain.Enums.TaskStatus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1. Register services here (DbContext, logging, etc.)
builder.Services.AddDbContext<UtopiaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UtopiaDb"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Utopia API is running");

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 3. Add middleware here (authentication, authorization, etc.)
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 4. Map endpoints here (Minimal APIs)
var tasks = app.MapGroup("/tasks");

tasks.MapPost("/", async (CreateTaskRequest request, UtopiaDbContext db) =>
{
    var task = new TaskItem
    {
        Id = Guid.NewGuid(),
        ProjectId = request.ProjectId,
        Title = request.Title,
        Description = request.Description,
        Status = TaskStatus.Pending,
        CreatedAt = DateTime.UtcNow
    };

    db.Tasks.Add(task);
    await db.SaveChangesAsync();

    // TODO: Publish TaskCreatedMessage (next step)

    return Results.Created($"/tasks/{task.Id}", task);
});

app.Run();
