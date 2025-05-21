using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.ModelData;
using Microsoft.EntityFrameworkCore;

namespace DATA.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        SpDbContext spDbContext { get; }
        DbSet<TEntity> Entity { get; }
        Task<TEntity> CreateAsync(TEntity entity);
        void Detached(TEntity entity);
        Task<TEntity> Put(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task<bool> DeleteRange(ICollection<TEntity> range);
        IQueryable<TEntity> AsQueryable();
        Task<int> Save();
        void Dispose();
    }
}
