using Libe.AccountMicroservice.Business.Dtos;
using Libe.AccountMicroservice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Business.Interfaces
{
    public interface IAccountService
    {
        Task<User> LogInAsync(LogInDto dto);
        Task<User> RegisterAsync(RegisterDto dto);
    }
}
