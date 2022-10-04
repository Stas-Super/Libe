using Libe.AccountMicroservice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize);
        Task DeleteAsync(int id);
    }
}
