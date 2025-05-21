using DATA.ModelData;

namespace DATA.Interfaces
{
    public interface IProfesorMateriaServiceDAO
    {
        Task<ProfesorMateria> CreateAsync(ProfesorMateria entity);
        Task<ProfesorMateria> UpdateAsync(ProfesorMateria entity);
        Task<ProfesorMateria> DeleteAsync(ProfesorMateria entity);
        Task<IEnumerable<ProfesorMateria>> GetAllAsync();
        Task<ProfesorMateria?> GetByIdAsync(int id);
    }
}
