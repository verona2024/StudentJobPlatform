using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var jobsPath = Path.Combine(builder.Environment.ContentRootPath, "jobs.json");
var applicationsPath = Path.Combine(builder.Environment.ContentRootPath, "applications.json");
var usersPath = Path.Combine(builder.Environment.ContentRootPath, "users.json");

builder.Services.AddSingleton<IRepository<Job>>(sp => new FileRepository<Job>(jobsPath));
builder.Services.AddSingleton<IRepository<Application>>(sp => new FileRepository<Application>(applicationsPath));
builder.Services.AddSingleton<IRepository<User>>(sp => new FileRepository<User>(usersPath));

builder.Services.AddSingleton<JobService>();

builder.Services.AddSingleton<ApplicationService>(sp =>
{
    var appRepo = sp.GetRequiredService<IRepository<Application>>();
    var jobRepo = sp.GetRequiredService<IRepository<Job>>();
    return new ApplicationService(appRepo, jobRepo);
});

builder.Services.AddSingleton<AuthService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();