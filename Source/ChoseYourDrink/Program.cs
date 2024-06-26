using ChoseYourDrink;
using ChoseYourDrink.Models;
using ChoseYourDrink.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using ChoseYourDrink.BLL;
using System.Reflection;
using ChoseYourDrink.BLL.HttpClients;
using Blazored.Toast;
using AutoMapper.Internal;
using AutoMapper;

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

// Fix for WASM
try
{
    var a = typeof(Enum);
    var l = typeof(Enum).StaticGenericMethod("Parse", parametersCount: 2);
    var t = Enum.Parse<StringComparison>("CurrentCulture", true);
    var h = t.ToString();

}
catch (Exception ex)
{

    throw;
}


builder.Services.AddSingleton(new MapperConfiguration(cfg =>
{
    cfg.AddMaps(Assembly.GetExecutingAssembly());
    cfg.AddMaps(Assembly.GetAssembly(typeof(ChoseYourDrink.BLL.DrinkService)));
    cfg.ShouldMapProperty = p => p.SetMethod?.IsPublic ?? false;
}));
builder.Services.AddScoped(sp => sp.GetRequiredService<MapperConfiguration>().CreateMapper());


//builder.Services.AddAutoMapper(cfg =>
//{
//    cfg.AddMaps(Assembly.GetExecutingAssembly());
//    cfg.AddMaps(Assembly.GetAssembly(typeof(ChoseYourDrink.BLL.DrinkService)));
//    cfg.ShouldMapProperty = p => p.SetMethod?.IsPublic ?? false;
//});

await builder.Build().RunAsync();
