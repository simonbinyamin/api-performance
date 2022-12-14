using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class StudentSerializerController : ApiController
    {
        private readonly IStudentSerializer _studentSerializer;
        public StudentSerializerController()
        {
            _studentSerializer = new StudentSerializer();

        }

        public string Get()
        {
            var student = _studentSerializer.StudentToString();
            return student;
        }





    }
}
