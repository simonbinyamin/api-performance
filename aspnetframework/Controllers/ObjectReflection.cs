using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class ObjectReflectionController : ApiController
    {
        private readonly IFindText _findText;
        public ObjectReflectionController()
        {
            _findText = new FindText();

        }

        public string Get()
        {
            var obj =_findText.PropertyFromObject();
            return obj;
        }





    }
}
