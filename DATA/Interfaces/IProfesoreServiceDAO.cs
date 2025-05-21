using DATA.ModelData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATA.Interfaces
{
    public interface IProfesoreServiceDAO
    {
        Task<Profesore> CreateAsync(Profesore entity);
        Task<Profesore> UpdateAsync(Profesore entity);
        Task<Profesore> DeleteAsync(Profesore entity);
        Task<IEnumerable<Profesore>> GetAllAsync();
        Task<Profesore?> GetByIdAsync(int id);
    }
}
