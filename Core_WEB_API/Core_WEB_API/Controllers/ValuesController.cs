using Core_CRUD.Models;
using Core_CRUD.Repository;
using Core_WEB_API.Model;
using Core_WEB_API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_WEB_API.Controllers
{
    [Route("api/[controller]")]
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
        public List<User> Get()
        {
            CRUD_Repository repository = new CRUD_Repository(_configuration);
            List<User> users = repository.GetAll();
            return users;
        }



        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<User> Get(int id)
        {
            CRUD_Repository repository = new CRUD_Repository(_configuration);
            List<User>users = repository.Getone(id);
            return users;
        }
        //POST api/<ValuesController>
        [HttpPost]
        public void Post(User user)
        {
           CRUD_Repository repo = new CRUD_Repository(_configuration);
            repo.Insert(user);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(User user, int id)
        {
            CRUD_Repository repo = new CRUD_Repository(_configuration);
            repo.Update(user,id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CRUD_Repository repo = new CRUD_Repository(_configuration);
            repo.Delete(id);
        }
    }
}
