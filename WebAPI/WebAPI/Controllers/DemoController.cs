﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DemoController : ApiController
    {
        public string Get()
        {
            return "Welcome To Web API";
        }
    }
}
