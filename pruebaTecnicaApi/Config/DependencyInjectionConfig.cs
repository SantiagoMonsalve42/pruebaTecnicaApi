using COMMON.Utilities;
using DATA.Common;
using DATA.Implementations;
using DATA.Interfaces;
using DATA.ModelData;
using NEGOCIO.Implementations;
using NEGOCIO.Interfaces;

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
            //DAO DEPENDECY INJETCION
            services.AddScoped<IEstudianteServiceDAO, EstudianteServiceDAO>();
            services.AddScoped<IMateriaServiceDAO, MateriaServiceDAO>();
            services.AddScoped<IProfesorMateriaServiceDAO, ProfesorMateriaServiceDAO>();
            services.AddScoped<IProfesoreServiceDAO, ProfesoreServiceDAO>();
            services.AddScoped<IEstudianteMateriaServiceDAO, EstudianteMateriaServiceDAO>();
            services.AddScoped<IEstudianteServiceDAO, EstudianteServiceDAO>();
            //NEGOCIO DEPENDECY INJETCION
            services.AddScoped<ISesionService, SesionService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IEstudianteService, EstudianteService>();
        }
    }
}
