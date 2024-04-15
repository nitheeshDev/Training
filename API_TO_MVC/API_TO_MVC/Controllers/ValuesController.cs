using API_TO_MVC.Model;
using API_TO_MVC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TO_MVC.Controllers
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
        [HttpPost]
        public void Post(Register register, IFormFile profile)
        {
            studenRepository studenRepository = new studenRepository(_configuration);
            studenRepository.inserStudent(register, profile); 
        }

    }
}
