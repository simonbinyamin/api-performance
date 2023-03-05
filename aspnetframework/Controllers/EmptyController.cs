using aspnetframework.Services;
using common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class EmptyController : ApiController
    {
        
        public EmptyController()
        {
           
        }
        public bool Get()
        {
            Debug.WriteLine("My current thread is: " + Thread.CurrentThread.ManagedThreadId);
            return true;
        }
    }
}
