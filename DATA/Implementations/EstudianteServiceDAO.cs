using DATA.Common;
using DATA.Interfaces;
using DATA.ModelData;
using Microsoft.EntityFrameworkCore;
namespace DATA.Implementations
{
    public class EstudianteServiceDAO : IEstudianteServiceDAO
    {
        private readonly IRepository<Estudiante> _repository;

        public EstudianteServiceDAO(IRepository<Estudiante> repository)
        {
            _repository = repository;
        }

        public async Task<Estudiante> CreateAsync(Estudiante entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<Estudiante> UpdateAsync(Estudiante entity)
        {
            return await _repository.Put(entity);
        }

        public async Task<Estudiante> DeleteAsync(Estudiante entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _repository.AsQueryable().ToListAsync();
        }
        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await (from row in _repository.Entity where row.EstudianteId == id select row).FirstOrDefaultAsync();
        }
    }
}
