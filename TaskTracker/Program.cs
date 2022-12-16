using Microsoft.EntityFrameworkCore;
using TaskTracker.Bll.TaskTracker.BLL.Interfaces;
using TaskTracker.Bll.TaskTracker.BLL.Services;
using TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.Services;
using TaskTracker.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<IUnitOfWork, EFUnitOfWork>();
services.AddDbContext<TaskTracker.DAL.EF.TaskTrackerDB>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("default")));
services.AddTransient<IProjectService, ProjectService>();
services.AddTransient<IProjectTaskService, ProjectTaskService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors(option =>
{
    option.AllowAnyHeader();
    option.AllowAnyMethod();
    option.AllowAnyOrigin();
});

app.Run();
