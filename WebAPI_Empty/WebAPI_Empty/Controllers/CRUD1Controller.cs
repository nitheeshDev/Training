using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Empty.Controllers
{
    public class CRUD1Controller : ApiController
    {
        // GET: api/CRUD1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CRUD1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CRUD1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CRUD1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CRUD1/5
        public void Delete(int id)
        {
        }
    }
}
