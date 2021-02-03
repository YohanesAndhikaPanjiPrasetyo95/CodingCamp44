using CodingCamp44.Base.Controller;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
using CodingCamp44.ViewModels;
using CodingCamp44.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingController : BaseController<Profiling, ProfilingRepository, string>
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly ProfilingRepository profilingRepository;

        public ProfilingController(IJWTAuthenticationManager jwtAuthenticationManager, ProfilingRepository profilingRepository) : base(profilingRepository) 
        {
           this.profilingRepository = profilingRepository;
           this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
    }
}

