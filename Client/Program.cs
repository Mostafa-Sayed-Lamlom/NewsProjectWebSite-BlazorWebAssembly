using BlazorApp1.Client;
using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Dtos;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IMainServices<Category>, MainServices<Category>>();
builder.Services.AddScoped<IMainServices<NewsList>, MainServices<NewsList>>();
builder.Services.AddScoped<IMainServices<NewsListDto>, MainServices<NewsListDto>>();
builder.Services.AddScoped<IMainServices<Comment>, MainServices<Comment>>();
await builder.Build().RunAsync();
