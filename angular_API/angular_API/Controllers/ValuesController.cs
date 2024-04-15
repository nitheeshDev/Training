using angular_API.Model;
using angular_API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace angular_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ValuesController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Register> Get()
        {
            userInsert insert = new userInsert(_configuration);
            List<Register> result = insert.get();
            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        
        [HttpPost]
        public void Post(Register register)
        {
            userInsert user = new userInsert(_configuration);
            user.Insert(register);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Register register,int id)
        {
            userInsert user = new userInsert(_configuration);
            user.update(register,id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userInsert user = new userInsert(_configuration);
            user.Del(id);
        }
    }
}
