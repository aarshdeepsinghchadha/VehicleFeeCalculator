using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VehicleFees.Common.Handlers;
using VehicleFees.Common.Interface;
using VehicleFees.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IVehicleFeesService, VehicleFeesService>();
// Configure MediatR
// Register MediatR
builder.Services.AddMediatR(typeof(VehicleFeesCommandHandler));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VehicleCalculator}/{action=Index}/{id?}");

app.Run();