using CodingCamp44.Base.Controller;
using CodingCamp44.JWT;
using CodingCamp44.Models;
using CodingCamp44.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : BaseController<Education, EducationRepository, int>
    {
        EducationRepository educationRepository;
        public EducationController(EducationRepository educationRepository) : base(educationRepository)
        {
            this.educationRepository = educationRepository;
        }
    }
}
