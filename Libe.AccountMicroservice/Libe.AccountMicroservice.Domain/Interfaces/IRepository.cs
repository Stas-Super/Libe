using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Domain.Interfaces
{
    public interface IRepository<T, Tkey>
    {
        Task CreateAsync(T item, CancellationToken cancellationToken = default);
        Task UpdateAsync(T item, CancellationToken cancellationToken = default);
        Task DeleteAsync(Tkey id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T> GetByIdAsync(int id);
    }
}
