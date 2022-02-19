using Libe.Domain.Core.Base;
using Libe.Domain.Interfaces.Interfaces;
using Libe.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Infrastructure.Data.Repositories.Base
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey>
        where T : BaseEntity<int>
        where TKey : struct
    {
        protected readonly ApiDbContext _ctx;
        
        public BaseRepository(ApiDbContext ctx) =>
            _ctx = ctx;

        public async Task<T> Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(TKey id)
        {
            var entity = await _ctx.Set<T>()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<T> Get(TKey id)
        {
            return await _ctx.Set<T>().Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
           var updatetable = _ctx.Set<T>().Update(entity);
           await _ctx.SaveChangesAsync();
            return updatetable.Entity;
        }
    }
}
