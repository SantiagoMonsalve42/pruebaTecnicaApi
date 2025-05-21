using DATA.ModelData;

namespace DATA.Interfaces
{
    public interface IEstudianteMateriaServiceDAO
    {
        Task<EstudianteMateria> CreateAsync(EstudianteMateria entity);
        Task<EstudianteMateria> UpdateAsync(EstudianteMateria entity);
        Task<EstudianteMateria> DeleteAsync(EstudianteMateria entity);
        Task<IEnumerable<EstudianteMateria>> GetAllAsync();
        Task<List<EstudianteMateria?>> GetByIdAsync(int id);
    }
}
