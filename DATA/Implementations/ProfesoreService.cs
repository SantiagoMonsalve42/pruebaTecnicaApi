using DATA.Common;
using DATA.Interfaces;
using DATA.ModelData;
using Microsoft.EntityFrameworkCore;

namespace DATA.Implementations
{
    public class ProfesoreService : IProfesoreService
    {
        private readonly IRepository<Profesore> _repository;

        public ProfesoreService(IRepository<Profesore> repository)
        {
            _repository = repository;
        }

        public async Task<Profesore> CreateAsync(Profesore entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<Profesore> UpdateAsync(Profesore entity)
        {
            return await _repository.Put(entity);
        }

        public async Task<Profesore> DeleteAsync(Profesore entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<Profesore>> GetAllAsync()
        {
            return await _repository.AsQueryable().ToListAsync();
        }
        public async Task<Profesore?> GetByIdAsync(int id)
        {
            return await (from row in _repository.Entity where row.ProfesorId == id select row).FirstOrDefaultAsync();
        }
    }
}
