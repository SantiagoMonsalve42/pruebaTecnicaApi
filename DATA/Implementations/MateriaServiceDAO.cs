using DATA.Common;
using DATA.Interfaces;
using DATA.ModelData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATA.Implementations
{
    public class MateriaServiceDAO : IMateriaServiceDAO
    {
        private readonly IRepository<Materia> _repository;

        public MateriaServiceDAO(IRepository<Materia> repository)
        {
            _repository = repository;
        }

        public async Task<Materia> CreateAsync(Materia entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<Materia> UpdateAsync(Materia entity)
        {
            return await _repository.Put(entity);
        }

        public async Task<Materia> DeleteAsync(Materia entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<Materia>> GetAllAsync()
        {
            return await _repository.AsQueryable().ToListAsync();
        }
        public async Task<Materia?> GetByIdAsync(int id)
        {
            return await (from row in _repository.Entity where row.MateriaId == id select row).FirstOrDefaultAsync();
        }
    }
}
