using Microsoft.OpenApi.Models;

namespace pruebaTecnicaApi.Config
{
    public static class SwaggerConfig
    {
        public static void SwaggerConfigurationServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaTecnica.Interrapidisimo.Api", Version = "v1" });
            });
        }
    }
}
