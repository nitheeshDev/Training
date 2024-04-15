using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Insert()
        {
            ViewBag.Title = "Inserted";

            return View();
        }
        [HttpPost]
        public ActionResult Insert(User user)
        {
            CRUD cRUD = new CRUD();
            cRUD.Insert(user);
            return View();
        }
        public ActionResult getall()
        {
            CRUD cRUD = new CRUD();
            List<User> users = cRUD.GetAll(); 
            return View(users);
        }
        public ActionResult Update(int id)
        {
            CRUD cRUD = new CRUD();
            return View(cRUD.Getone(id).Find(e => e.Id == id));
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            CRUD cRUD = new CRUD();
            cRUD.Insert(user);
            return View(cRUD);
        }
    }
}
