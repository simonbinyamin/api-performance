using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class ReplaceTextController : ApiController
    {
        private readonly IFindText _findText;
        public ReplaceTextController()
        {
            _findText = new FindText();

        }

        public string Get()
        {
            var repl =_findText.ReplaceChar();
            return repl;
        }





    }
}
