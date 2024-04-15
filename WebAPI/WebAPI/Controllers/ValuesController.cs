using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        /// <summary>
        /// Get all details
        /// </summary>
        /// <returns></returns>
        public List<User> Get()
        {
            CRUD cRUD = new CRUD();
            cRUD.GetAll();
            return cRUD.GetAll();
        }

        // GET api/values/5

        /// <summary>
        /// Get one user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<User> Get(int id)
        {
            CRUD cRUD= new CRUD();
            cRUD.Getone(id);
            return cRUD.Getone(id);
        }

        // POST api/values
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Post(User user)
        {
            string msg;
            if(user != null) 
            {
                CRUD cRUD = new CRUD();
                cRUD.Insert(user);
                msg = "Data successfully added";
            }
            else
            {
                msg = "Data not successfully added";
            }
            return msg;
            
        }

        // PUT api/values/5

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="user"></param>
        public void Put(User user)
        {
            CRUD cRUD = new CRUD();
            cRUD.Update(user);
        }

        // DELETE api/values/5

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user)
        {
            CRUD cRUD = new CRUD();
            cRUD.Delete(user);
        }
    }
}
