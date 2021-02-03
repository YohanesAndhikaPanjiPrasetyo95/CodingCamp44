using CodingCamp44.Context;
using CodingCamp44.Repositories;
using CodingCamp44.Repositories.Interfaces;
using CodingCamp44.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodingCamp44.Base.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class BaseController<Entity, Repository, Id> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Id>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            var data = repository.Get();
            return (data != null) ? (ActionResult)Ok(new { data = data, status = "Ok" }) : StatusCode(500, new { data = data, status = "Internal Server Error", errorMessage = "Cannot get the data" });        
        }

        [HttpGet("{id}")]
        public ActionResult Get(Id id)
        {
            var data = repository.Get(id);
            return (data != null) ? (ActionResult)Ok(new { data = data, status = "Ok" }) : NotFound(new { data = data, status = "Not Found", errorMessage = "ID is not identified" }); 
        }

        [HttpPost]
        public ActionResult Create(Entity entity)
        {
            if (entity == null)
                return BadRequest(new { status = "Bad Request", errorMessage = "All input data need to be inserted" });
            var data = repository.Create(entity);
            return (data != 0) ? (ActionResult)Ok(new { data = data, status = "Ok" }) : StatusCode(500, new { status = "Internal Server Error", errorMessage = "Failed to input the data" }); 
        }

        [HttpPut]
        public ActionResult Update(Id id, Entity entity)
        {
            if (repository.Get(id) != null)
            {
            	return NotFound("ID Not Found");
            }
            else
            {
                try
                {
                    var data = repository.Update(id, entity);
                    return Ok(new { data = data, status = "Ok" });
                }
                catch (Exception)
                {
		            return StatusCode(500, new { status = "Internal Server Error", errorMessage = "Failed to input the data" });
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Id id)
        {
            if (repository.Get(id) == null) 
            {
                return NotFound("ID Not Found");
            }
            else
            {
                var data = repository.Delete(id);
                return (data != 0) ? (ActionResult)Ok(new {status = "Ok"}) : StatusCode(500, new {status = "Internal Server Error" });
            }
        }    
    }
}
