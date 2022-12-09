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
        private readonly IFindText _findText;
        public StudentSerializerController()
        {
            _findText = new FindText();

        }

        public string Get()
        {
            var str = _findText.StudentToString();
            return str;
        }





    }
}
