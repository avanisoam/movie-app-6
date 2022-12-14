using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using movie_app_6.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<movie_app_6Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("movie_app_6Context") ?? throw new InvalidOperationException("Connection string 'movie_app_6Context' not found.")));

//https://stackoverflow.com/questions/40059929/cannot-find-the-usemysql-method-on-dbcontextoptions
//package Pomelo.EntityFrameworkCore.MySql

//builder.Services.AddDbContextPool<movie_app_6Context>(options =>
//{
//    var connetionString = builder.Configuration.GetConnectionString("MovieContext");
//    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
//});

builder.Services.AddDbContext<movie_app_6Context>(options =>
    options.UseInMemoryDatabase(databaseName: "MovieDb"));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
