using Microsoft.EntityFrameworkCore;
using WypozyczalniaSamochodow.Context;
using WypozyczalniaSamochodow.Services;
using WypozyczalniaSamochodow.Services.Car;
using WypozyczalniaSamochodow.Services.Rentals;
using WypozyczalniaSamochodow.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CarRentalDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("CarRentalDbContext")));
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
