using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private ICollegeRepositry repo;

        public CollegeController(ICollegeRepositry repo)
        {
            this.repo = repo;
        }

        //Get: api/College
        [HttpGet]
        public IEnumerable<College> Get()
        {
            return repo.GetAll();
        }

        //Get: api/College/5
        [HttpGet("{Id}", Name ="Get")]
        public College Get(int id)
        {
            try
            {
                return repo.GetCollege(id);
            }catch(CollegeException ex)
            {
                Response.StatusCode = 400;
                return null;
            }
        }

        //Get: api/College
        [HttpGet]
        [HttpHead]
        public IEnumerable<College> Getall()
        {
            return repo.GetAll();
        }

        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public ActionResult<College> GetAction(int id)
        {
            try
            {
                return repo.GetCollege(id);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [HttpHead]
        public IEnumerable<College> GetAllByName([FromQuery] string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return repo.GetAllByName(name);
            else
                return repo.GetAll();

        }

        //Get: api/College
        [HttpGet]
        [HttpHead]
        public IEnumerable<College> GetAllByNameAndLocation([FromQuery] string name, [FromQuery] string location)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!string.IsNullOrWhiteSpace(location.Trim()))
                    return repo.GetAllByNameAndLocation(name, location);
                else
                    return repo.GetAllByName(name);
            }
            else
            {
                return repo.GetAll();
            }
        }
    }
}
