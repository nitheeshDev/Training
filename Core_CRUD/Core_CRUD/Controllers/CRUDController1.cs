using Core_CRUD.Models;
using Core_CRUD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController1 : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CRUDController1(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Register> Post(int id)
        {
            studenRepository studenrepository = new studenRepository(_configuration);
            List<Register> students = studenrepository.getStudents(id);
            return students;
        }
    }
}
