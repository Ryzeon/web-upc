using System.Collections.Generic;
using System.Threading.Tasks;

namespace pratica_pc2_1.API.Shared.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> FindByIdAsync(int id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> ListAsync();
    }
}
