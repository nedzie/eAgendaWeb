using eAgenda.WebAPI.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace eAgenda.WebAPI.Config
{
    public static class FiltersConfig
    {
        public static void ConfigurarFiltros(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add<ValidarViewModelActionFilter>();
            });
        }
    }
}
