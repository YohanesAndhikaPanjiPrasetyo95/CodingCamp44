using CodingCamp44.Base.Controller;
using CodingCamp44.Context;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories;
using CodingCamp44.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodingCamp44.Handler;
using CodingCamp44.JWT;

namespace CodingCamp44.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    //TESTTTT
    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly PersonRepository personRepository;
        
        private IConfiguration Configuration;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public AccountController(AccountRepository accountRepository, PersonRepository personRepository, IConfiguration Configuration, IJWTAuthenticationManager jWTAuthenticationManager) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.personRepository = personRepository;
            this.Configuration = Configuration;
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        /*[HttpPost("/Login")]
        public IActionResult Login([FromBody] LoginVM login)
        {
            IActionResult response = Unauthorized();
            var user = accountRepository.Login(login.Email, login.Password);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }*/

        [HttpPut("ChangePassword/{NIK}")]
        public ActionResult ChangePassword(string NIK, ChangePasswordVM changePasswordVM) 
        {
            var acc = accountRepository.Get(NIK);
            if (acc != null)
            {
                if (acc.Password == changePasswordVM.OldPassword)
                {
                    var data = accountRepository.ChangePassword(NIK, changePasswordVM.NewPassword);
                    return Ok(data);
                }
                else 
                {
                    return StatusCode(404, new { status = "404", message = "Wrong password" });
                }
            }
            return NotFound();
        }

        [HttpPut("reset/{email}/{id}")]
        public ActionResult ResetPassword(Account account, string email)
        {
            var data = accountRepository.ResetPassword(account, email);
            return (data > 0) ? (ActionResult)Ok(new { message = "Email has been Sent, password changed", status = "Ok" }) : NotFound(new { message = "Data not exist in our database, please register first", status = 404 });
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var data = accountRepository.Register(registerVM);
                if (data > 0)
                {
                    return Ok(new { status = "Registration Successed..." });
                }
                else
                {
                    return StatusCode(500, new { status = "Internal server error..." });
                }
            }
            else {
                return BadRequest(new { status = "Bad request...", errorMessage = "Data input is not valid..."});
            }
        }
    }
}

