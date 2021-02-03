using CodingCamp44.Base.Controller;
using CodingCamp44.JWT;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using CodingCamp44.Repositories.Interfaces;
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
    //[ApiController]
    [Authorize]
    public class JobController : BaseController<Job, JobRepository, int>
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly JobRepository jobRepository;

        public JobController(IJWTAuthenticationManager jwtAuthenticationManager, JobRepository jobRepository) : base(jobRepository)
        {
            this.jobRepository = jobRepository;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
    }
}