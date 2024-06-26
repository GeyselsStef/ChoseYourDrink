using ChoseYourDrink;
using ChoseYourDrink.Models;
using ChoseYourDrink.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using ChoseYourDrink.BLL;
using ChoseYourDrink.BLL.HttpClients;
using Blazored.Toast;
using Mapper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DrinksHttpClient>();
builder.Services.AddScoped<OrderApiHttpClient>();
builder.Services.AddScoped<ChoseYourDrink.Services.IDrinkService, ChoseYourDrink.Services.DrinkService>();
builder.Services.AddScoped<ChoseYourDrink.BLL.IDrinkService, ChoseYourDrink.BLL.DrinkService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddTransient<IJSRunitmeServices, JSRunitmeServices>();

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

builder.Services.AddMapper();

Console.WriteLine("Hello, World!");

await builder.Build().RunAsync();
