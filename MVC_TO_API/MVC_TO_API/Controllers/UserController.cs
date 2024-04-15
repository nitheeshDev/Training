using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Emit;

namespace MVC_TO_API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Insert() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Insert(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7279/");

                try
                {
                    var response = await client.PostAsJsonAsync("api/Values", user);

                    if (response != null)
                    {
                        ViewBag.User = "Successfully inserted";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.User = "Insertion failed: " + ex.Message;
                }

                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7279/");

                try
                {
                    var response = await client.GetAsync("api/Values");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var userList = JsonConvert.DeserializeObject<List<User>>(content);

           
                        return View(userList);
                    }
                    else
                    {
                        ViewBag.User = "Failed to retrieve data. Status code: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.User = "Insertion failed: " + ex.Message;
                }

                return View();
            }
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<ActionResult> Update(User user,int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7279/");

                try
                {
                    var response = await client.PutAsJsonAsync($"api/Values/{id}", user);


                    if (response != null)
                    {
                        return RedirectToAction("Get");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.User = "Insertion failed: " + ex.Message;
                }

                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(User user, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7279/");

                try
                {
                    var response = await client.DeleteAsync($"api/Values/{id}");


                    if (response != null)
                    {
                        return RedirectToAction("Get");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.User = "Insertion failed: " + ex.Message;
                }

                return View();
            }
        }
    }
}
