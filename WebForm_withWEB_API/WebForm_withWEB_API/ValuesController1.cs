using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForm_withWEB_API.Model;
using WebForm_withWEB_API.Repository;

namespace WebForm_withWEB_API
{
    public class ValuesController1 : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            CRUD cRUD = new CRUD();
            cRUD.GetAll();
            return cRUD.GetAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] User user)
        {
            string msg;

            if (user != null)
            {
                CRUD cRUD = new CRUD();
                cRUD.Insert(user);
                msg = "Data successfully added";
                return Ok(msg); 
            }
            else
            {
                msg = "Data not successfully added";
                return BadRequest(msg); 
            }
        }


        // PUT api/<controller>/5
        public void Put(User user)
        {
            CRUD cRUD = new CRUD();
            cRUD.Update(user);
        }

        // DELETE api/<controller>/5
        public void Delete(User user)
        {
            CRUD cRUD = new CRUD();
            cRUD.Delete(user);
        }
    }
}