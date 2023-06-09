using App.DAO;
using App.DAOInterface;
using App.Logic;
using App.LogicInterface;
using FileData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IProjectDAO, ProjectDAO>();
builder.Services.AddScoped<IProjectLogic, ProjectLogic>();
builder.Services.AddScoped<ITaskDAO, TaskDAO>();
builder.Services.AddScoped<ITaskLogic, TaskLogic>();
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