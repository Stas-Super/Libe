using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Domain.Interfaces.Interfaces
{
    public interface IRepository<T,Tkey>
    {
        Task<T> Create(T entity);
        Task Delete(Tkey id);
        Task<T> Get(Tkey id);
        Task<List<T>> GetAll();
        Task<T> Update(T entity);
    }
}
