using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libe.DAL.Interfaces
{
    public interface IRepository<T,Tkey> 
    {
        Task Create(T item);
        Task Delete(Tkey id);
        Task<T> Get(Tkey id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
    }
}
