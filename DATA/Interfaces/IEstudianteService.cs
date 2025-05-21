using DATA.ModelData;

namespace DATA.Interfaces
{
    public interface IEstudianteService
    {
        Task<Estudiante> CreateAsync(Estudiante entity);
        Task<Estudiante> UpdateAsync(Estudiante entity);
        Task<Estudiante> DeleteAsync(Estudiante entity);
        Task<IEnumerable<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
    }
}
