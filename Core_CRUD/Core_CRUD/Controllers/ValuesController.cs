using Core_CRUD.Models;
using Core_CRUD.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_CRUD.Controllers
{
    

    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Register> Get(int id)
        {
            studenRepository studenRepository = new studenRepository(_configuration);
            List<Register> students = studenRepository.getStudents(id);
            return students;
        }

        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Register register, IFormFile imageFile)
        {
            studenRepository studenrepository = new studenRepository(_configuration);
            studenrepository.inserStudent(register, imageFile);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
