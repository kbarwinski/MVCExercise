using Microsoft.AspNetCore.Hosting;
using MVCExercise.Extensions;
using MVCExercise.Infrastructure;
using MVCExercise.Persistence;


var builder = WebApplication.CreateBuilder(args);

var cfg = builder.Configuration;

builder.Services.ConfigurePersistence(cfg);

builder.Services.ConfigureInfrastructure(cfg);

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseCors();

app.UseErrorHandler();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
