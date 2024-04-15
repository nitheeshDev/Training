using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Empty.Models;
using WebAPI_Empty.Repository;

namespace WebAPI_Empty.Controllers
{
    public class CRUDController : ApiController
    {

        public IEnumerable<User> Get()
        {
            CRUD_Repository cRUD = new CRUD_Repository();
            var users = cRUD.GetAll();
            return users;
        }

        //public List<User> Get()
        //{
        //    CRUD_Repository cRUD = new CRUD_Repository();
        //    cRUD.GetAll();
        //    return cRUD.GetAll();
        //}
        public string Post(User user)
        {
            string msg;
            
            if (user != null)
            {
                CRUD_Repository cRUD = new CRUD_Repository();
                cRUD.Insert(user);
                msg = "Data successfully added";
            }
            else
            {
                msg = "Data not successfully added";
            }
            return msg;
        }
        public void Put(User user)
        {
            CRUD_Repository cRUD = new CRUD_Repository();
            cRUD.Update(user);
        }
        public void Delete(int id)
        {
            CRUD_Repository cRUD = new CRUD_Repository();
            cRUD.Delete(id);
        }
    }
}
