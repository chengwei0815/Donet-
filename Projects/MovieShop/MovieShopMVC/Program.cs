using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Middlewares;
using MovieShopMVC.Services;
using Serilog;

//Configure Serilog before builder creation
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/movieshop_log_.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);
//replaces built-in logging with Serilog
builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieRepository, MovieResository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "MovieShopAuthCookie";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.LoginPath = "/account/login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseMovieShopExceptionMiddleware();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
