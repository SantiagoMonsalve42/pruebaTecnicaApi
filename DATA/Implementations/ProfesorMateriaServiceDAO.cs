using Azure.Core;
using DATA.Common;
using DATA.Interfaces;
using DATA.ModelData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATA.Implementations
{
    public class ProfesorMateriaServiceDAO : IProfesorMateriaServiceDAO
    {
        private readonly IRepository<ProfesorMateria> _repository;

        public ProfesorMateriaServiceDAO(IRepository<ProfesorMateria> repository)
        {
            _repository = repository;
        }

        public async Task<ProfesorMateria> CreateAsync(ProfesorMateria entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<ProfesorMateria> UpdateAsync(ProfesorMateria entity)
        {
            return await _repository.Put(entity);
        }

        public async Task<ProfesorMateria> DeleteAsync(ProfesorMateria entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<ProfesorMateria>> GetAllAsync()
        {
            return await _repository.AsQueryable().ToListAsync();
        }
        public async Task<ProfesorMateria?> GetByIdAsync(int id)
        {
            return await (from row in _repository.Entity where row.ProfesorId == id select row).FirstOrDefaultAsync();
        }
        public async Task<List<ProfesorMateria>> GetByIdMateriaAsync(int id)
        {
            return await (from row in _repository.Entity where row.MateriaId == id select row).ToListAsync();
        }
    }
}
