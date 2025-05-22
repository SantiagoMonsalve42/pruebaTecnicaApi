
using DATA.Common;
using DATA.Interfaces;
using DATA.ModelData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATA.Implementations
{
    public class EstudianteMateriaServiceDAO : IEstudianteMateriaServiceDAO
    {
        private readonly IRepository<EstudianteMateria> _repository;

        public EstudianteMateriaServiceDAO(IRepository<EstudianteMateria> repository)
        {
            _repository = repository;
        }

        public async Task<EstudianteMateria> CreateAsync(EstudianteMateria entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<EstudianteMateria> UpdateAsync(EstudianteMateria entity)
        {
            return await _repository.Put(entity);
        }

        public async Task<EstudianteMateria> DeleteAsync(EstudianteMateria entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<EstudianteMateria>> GetAllAsync()
        {
            return await _repository.AsQueryable().ToListAsync();
        }
        public async Task<List<EstudianteMateria?>> GetByIdAsync(int id)
        {
            return await (from row in _repository.Entity where row.EstudianteId == id select row).ToListAsync();
        }

        public async Task<bool> Delete(int idEstudiante, int idMateria)
        {
            EstudianteMateria? entry = await _repository.AsQueryable().Where(x=>x.EstudianteId==idEstudiante && x.MateriaId == idMateria).FirstOrDefaultAsync();
            if(entry != null)
            {
                _repository.Detached(entry);
                await _repository.Delete(entry);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
