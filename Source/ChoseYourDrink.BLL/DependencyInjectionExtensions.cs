using ChoseYourDrink.BLL.HttpClients;
using Microsoft.Extensions.DependencyInjection;

namespace ChoseYourDrink.BLL;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        services.AddScoped<OrderApiHttpClient>();

        services.AddScoped<IDrinkService, DrinkService>();
        return services;
    }
}