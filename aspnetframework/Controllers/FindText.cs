using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class FindTextController : ApiController
    {
        private readonly IFindText _findText;
        public FindTextController()
        {
            _findText = new FindText();

        }

        public string Get()
        {
            var r =_findText.FindTheWordMuch();
            return "value2";
        }





    }
}
