using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

string connstr = builder.Configuration.GetConnectionString("LocalDb");
//string connStr = builder.Configuration.GetConnectionString("RemoteDb");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CarDbContext>(opt => opt.UseSqlServer(connstr));

// Add Fluent Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Add Custom Services
// Singleton:
//builder.Services.AddSingleton<ICarService, CarService>();

//Scoped:
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICartService, CartService>();

// Transient:
//builder.Services.AddTransient<ICarService, CarService>();

builder.Services.AddSession(options =>
{
    //options.IdleTimeout= TimeSpan.FromDays(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();  

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
