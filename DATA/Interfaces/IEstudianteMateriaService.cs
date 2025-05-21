using DATA.ModelData;

namespace DATA.Interfaces
{
    public interface IEstudianteMateriaService
    {
        Task<EstudianteMateria> CreateAsync(EstudianteMateria entity);
        Task<EstudianteMateria> UpdateAsync(EstudianteMateria entity);
        Task<EstudianteMateria> DeleteAsync(EstudianteMateria entity);
        Task<IEnumerable<EstudianteMateria>> GetAllAsync();
        Task<EstudianteMateria?> GetByIdAsync(int id);
    }
}
