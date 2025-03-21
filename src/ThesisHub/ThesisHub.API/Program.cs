using Microsoft.EntityFrameworkCore;
using ThesisHub.Infrastructure.Interfaces;
using ThesisHub.Infrastructure.Repositories;
using ThesisHub.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ThesisHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThesisHubStrConnection") ?? throw new InvalidOperationException("Connection string 'ThesisHubContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

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