using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto dto)
        {
            var userToLogin = _authService.Login(dto);

            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var token = _authService.CreateAccessToken(userToLogin.Data);

            if (!token.IsSuccess)
            {
                return BadRequest(token.Message);
            }

            return Ok(token.Data);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto dto)
        {
            var userExists = _authService.UserExists(dto.Email);

            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var registerUser = _authService.Register(dto);
            var token = _authService.CreateAccessToken(registerUser.Data);

            if (!token.IsSuccess)
            {
                return BadRequest(token.Message);
            }

            return Ok(token.Data);
        }
    }
}