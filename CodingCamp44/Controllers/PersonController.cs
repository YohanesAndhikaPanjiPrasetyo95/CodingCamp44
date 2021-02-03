using CodingCamp44.Base.Controller;
using CodingCamp44.Handler;
using CodingCamp44.JWT;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
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
    //[Authorize]
    public class PersonController : BaseController<Person, PersonRepository, string>
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly PersonRepository personRepository;

        public PersonController(IJWTAuthenticationManager jwtAuthenticationManager, PersonRepository personRepository) : base(personRepository) 
        {
            this.personRepository = personRepository;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
    }
}
