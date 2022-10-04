using AutoMapper;
using Libe.AccountMicroservice.Business.Dtos;
using Libe.AccountMicroservice.Business.Interfaces;
using Libe.AccountMicroservice.Domain.Interfaces;
using Libe.AccountMicroservice.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(
            UserManager<User> userManager,
            IAccountRepository accountRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<User> LogInAsync(LogInDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                throw new Exception();

            var passwordValidationResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (passwordValidationResult == PasswordVerificationResult.Failed)
                throw new Exception();

            return user;
        }
    }
}
