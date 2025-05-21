using COMMON.Utilities;
using DATA.Common;
using DATA.ModelData;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace pruebaTecnicaApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependecyInjectionConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            HelperConfiguration.Configuration = Configuration;
            services.AddScoped<SpDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
