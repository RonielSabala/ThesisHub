using Microsoft.EntityFrameworkCore;
using ThesisHub.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ThesisHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThesisHubStrConnection") ?? throw new InvalidOperationException("Connection string 'ThesisHubContext' not found.")));

builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
