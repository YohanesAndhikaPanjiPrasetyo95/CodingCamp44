using CodingCamp44.Handler;
using CodingCamp44.JWT;
using CodingCamp44.Repositories.Data;
using CodingCamp44.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly AccountRepository accountRepository;
        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager, AccountRepository accountRepository)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.accountRepository = accountRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginVM loginVM)
        {
            var token = jWTAuthenticationManager.Generate(Login(loginVM));
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("/Login")]
        public LoginVM Login([FromBody] LoginVM login)
        {
            var user = accountRepository.Login(login.Email,login.Password);
            return user;
        }

    }
}
