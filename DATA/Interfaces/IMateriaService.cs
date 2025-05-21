using DATA.ModelData;

namespace DATA.Interfaces
{
    public interface IMateriaService
    {
        Task<Materia> CreateAsync(Materia entity);
        Task<Materia> UpdateAsync(Materia entity);
        Task<Materia> DeleteAsync(Materia entity);
        Task<IEnumerable<Materia>> GetAllAsync();
        Task<Materia?> GetByIdAsync(int id);
    }
}
