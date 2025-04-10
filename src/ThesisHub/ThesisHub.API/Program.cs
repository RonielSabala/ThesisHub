using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ThesisHub.Application.Services;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Infrastructure.Repositories;
using ThesisHub.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThesisHubStrConnection") ?? throw new InvalidOperationException("Connection string 'DataContext' not found.")));

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repositories
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Services
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<DepartmentService>();

var MyAllowSpecificOrigins = "AllowSpecificOrigins";
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: MyAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins("https://localhost:7240")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }
        );
    }
);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();