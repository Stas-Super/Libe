using Libe.AccountMicroservice.Domain.EF;
using Libe.AccountMicroservice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Domain.Repositories.Base
{
    public class BaseRepository<T, Tkey> : IRepository<T, Tkey>
        where T : Models.Base.BaseModel<Tkey>
    {
        private readonly AccountMicroserviceDbContext _ctx;
        public BaseRepository(AccountMicroserviceDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(T item, CancellationToken cancellationToken)
        {
            await _ctx.Set<T>().AddAsync(item);

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Tkey id, CancellationToken cancellationToken)
        {
            var item = await _ctx.Set<T>()
                .Where(i => i.Id.Equals(id))
                .FirstOrDefaultAsync();
            _ctx.Set<T>().Remove(item);

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _ctx.Set<T>()
                 .OrderBy(i => i.Id)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _ctx
                .Set<T>()
                .Where(i => i.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T item, CancellationToken cancellationToken)
        {
            var oldItem = await _ctx.Set<T>()
                .Where(i => i.Id.Equals(item.Id))
                .FirstOrDefaultAsync();
            _ctx.Update<T>(item);

            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}
