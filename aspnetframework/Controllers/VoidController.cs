using aspnetframework.Services;
using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class VoidController : ApiController
    {
        
        public VoidController()
        {
           
        }
        public bool Get()
        {
            return true;
        }
    }
}
