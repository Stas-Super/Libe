using Libe.AccountMicroservice.Domain.EF;
using Libe.AccountMicroservice.Domain.Interfaces;
using Libe.AccountMicroservice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Domain.Repositories
{
    public class AccountRepository : Base.BaseRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(AccountMicroserviceDbContext ctx) : base(ctx) { }

        public async Task CreateAsync(Account account)
        {
            await this.CreateAsync(account);
        }

        public async Task DeleteAsync(int id)
        {
            await this.DeleteAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await this.GetAllAsync(pageNumber, pageSize);
        }
    }
}
