using Core_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_WEB_API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Insert(Register register, IFormFile imageFile)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7279/");

                var response = client.PostAsJsonAsync("api/Values/Post", register).Result;

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
