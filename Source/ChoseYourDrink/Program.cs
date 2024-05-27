using ChoseYourDrink;
using ChoseYourDrink.Models;
using ChoseYourDrink.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new DrinksHttpClient());
builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
