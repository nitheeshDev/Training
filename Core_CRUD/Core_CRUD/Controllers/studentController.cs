using Core_CRUD.Models;
using Core_CRUD.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace Core_CRUD.Controllers
{
    public class studentController : Controller
    {
        private readonly IConfiguration _configuration;
        

        public studentController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Insert(Register student, IFormFile imageFile)
        //{
        //    studenRepository studenRepository = new studenRepository(_configuration);
        //    studenRepository.inserStudent(student, imageFile);
        //    return View(student);
        //}

        [HttpPost]
        public IActionResult Insert(Register student, IFormFile imageFile)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7195/");

                var response = client.PostAsJsonAsync("api/Values/Get", student).Result;

                if (response.IsSuccessStatusCode)
                {
                    return View(response);
                }
                else
                {
                    return View(response);
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll(int id)
        {
            studenRepository studenRepository = new studenRepository(_configuration);
            List<Register> students = studenRepository.getStudents(id);
            return View(students);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            studenRepository studenRepository = new studenRepository(_configuration);
            return View(studenRepository.getStudents(id).Find(e => e.Id == id));
        }
        [HttpPost]
        public IActionResult Update(Register register, IFormFile imageFile,int id)
        {
            studenRepository studenRepository = new studenRepository(_configuration);
            studenRepository.updateStudent(register, imageFile,id);
            return RedirectToAction("GetAll");
        }
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    studenRepository studenRepository = new studenRepository(_configuration);
        //    return View(studenRepository.getStudents(id).Find(e => e.Id == id));
        //}
        //[HttpPost]
        public IActionResult Delete(int id)
        {
            studenRepository studenRepository = new studenRepository(_configuration);
            studenRepository.deleteStudent(id);
            return RedirectToAction("GetAll");
        }
    }
}
