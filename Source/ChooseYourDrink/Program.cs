using ChooseYourDrink;
using ChooseYourDrink.Models;
using ChooseYourDrink.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using ChooseYourDrink.BLL;
using ChooseYourDrink.BLL.HttpClients;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DrinksHttpClient>();
builder.Services.AddScoped<ChooseYourDrink.Services.IDrinkService, ChooseYourDrink.Services.DrinkService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddTransient<IJSRunitmeServices, JSRunitmeServices>();

builder.Services.AddBLLServices();

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

Console.WriteLine("Hello, World! Met Automapper => BLL");

await builder.Build().RunAsync();
