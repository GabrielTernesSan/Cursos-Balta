using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handler;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(optional => optional.UseInMemoryDatabase("Database"));
//builder.Services.AddDbContext<DataContext>(optional => optional.UseSqlServer(Configuration.GetConnectionString("connectionString"));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

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
