using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repository;
using BlazorApp1.Server.Repository.Interfaces;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));
builder.Services.AddScoped<IMainInterface<Category>, MainRepository<Category>>();// update only when a new data added
builder.Services.AddScoped<IMainInterface<NewsList>, MainRepository<NewsList>>();
builder.Services.AddScoped<IMainInterface<Comment>, MainRepository<Comment>>();
//builder.Services.AddTransient<IMainInterface<Category>, CategoriesRepository>(); //update every all time(not good performance)
//builder.Services.AddSingleton<ICategories, CategoriesRepository>();// not update data 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
