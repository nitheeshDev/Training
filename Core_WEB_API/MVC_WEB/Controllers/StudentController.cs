using Core_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_WEB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Insert()
        {

            return View();
        }
        [HttpGet] 
        public ActionResult Getall(Register register,IFormFile file)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7279/");

                var response = client.PostAsJsonAsync("api/Values/Get", register).Result;

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
    }
}
