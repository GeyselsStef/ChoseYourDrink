using Microsoft.Extensions.DependencyInjection;

namespace Mapper
{
    public static class DependencyInjectionExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
