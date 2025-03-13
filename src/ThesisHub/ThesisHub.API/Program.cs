using Microsoft.EntityFrameworkCore;
using ThesisHub.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ThesisHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThesisHubStrConnection") ?? throw new InvalidOperationException("Connection string 'ThesisHubContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "AllowSpecificOrigins";
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: MyAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins("https://localhost:7149")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }
        );
    }
);

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

app.UseCors(MyAllowSpecificOrigins);

app.Run();
