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
    public class GetStudentsController : ApiController
    {
        private readonly IInMemoryFiltering _inMemoryFiltering;
        public GetStudentsController()
        {
            _inMemoryFiltering = new InMemoryFiltering();
        }
        public string Get()
        {
            var tB = _inMemoryFiltering.GetFilteredStudents();
            return "value";
        }
    }
}
