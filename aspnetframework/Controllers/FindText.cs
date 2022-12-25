using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

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

            _findText.FindTheWordMuch();

            return "Found";


        }





    }
}
