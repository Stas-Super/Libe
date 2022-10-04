using AutoMapper;
using Libe.AccountMicroservice.Business.Dtos;
using Libe.AccountMicroservice.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.ApiServices.Controllers
{
    [Route("api/user/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(ITokenService tokenService, IAccountService accountService, IMapper mapper)
        {
            _tokenService = tokenService;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromForm] LogInDto dto)
        {
            var user = await _accountService.LogInAsync(dto);

            if(user == null)
                return Unauthorized();

            var jwt = _tokenService.GenerateAccessToken(user);
            var refresh = _tokenService.GenerateRefreshToken();

            var userResponseDto = _mapper.Map<UserDto>(user);
            userResponseDto.AccessToken = jwt;
            userResponseDto.RefreshToken = refresh;
            userResponseDto.User = user;

            return Ok(userResponseDto);
        }
    }
}
