using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoccerLeagues.Database;
using SoccerLeagues.Seeder;
using SoccerLeagues.Application.Extensions;
using SoccerLeagues.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplication();
builder.Services.AddDatabase(builder.Configuration);


var app = builder.Build();
var scope = app.Services.CreateScope();
var seed = scope.ServiceProvider.GetRequiredService<SoccerLeaguesSeeder>();

await seed.SeedData();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
