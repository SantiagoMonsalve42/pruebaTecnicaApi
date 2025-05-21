using COMMON.Utilities;
using Microsoft.AspNetCore.Diagnostics;
using pruebaTecnicaApi.Config;
using pruebaTecnicaApi.Middleware;

namespace pruebaTecnicaApi
{
    public class StartUp
    {
        private string _MyCors = "MyCorsPolicyCustomable";
        public IConfiguration Configuration { get; }

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(op =>
            {
                op.AddPolicy(_MyCors, builder =>
                {
                    builder.WithOrigins(HelperConfiguration.GetParam("corsOrigin"))
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.SwaggerConfigurationServices();
            services.RegisterDependecyInjectionConfig(Configuration);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IExceptionHandler ex)
        {
            app.UseWebSockets();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaTecnica.Interrapidisimo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_MyCors);
            app.UseAuthorization();
            app.UseMiddleware<BasicAuthMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
