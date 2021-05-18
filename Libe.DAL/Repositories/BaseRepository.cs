using Libe.DAL.EF;
using Libe.DAL.Entities;
using Libe.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libe.DAL.Repositories
{
    public abstract class BaseRepository<T, Tkey> : IRepository<T, Tkey>
        where T : BaseEntity<Tkey>
        where Tkey : struct
    {
        protected ApiDbContext ctx;

        public BaseRepository(ApiDbContext ctx)
        {
            this.ctx = ctx;
        }

        public virtual async Task Create(T item)
        {
            await ctx.Set<T>().AddAsync(item);
        }

        public async Task Delete(Tkey id)
        {
            var entity = await ctx.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id));
            ctx.Set<T>().Remove(entity);
        }

        public async Task<T> Get(Tkey id)
        {
            var entity = await ctx.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id));
            return entity;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                return await ctx.Set<T>().AsQueryable().ToListAsync();
            }
            return await ctx.Set<T>().AsQueryable().Where(expression).ToListAsync();
        }
    }
}
