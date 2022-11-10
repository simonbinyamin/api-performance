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
    public class TaskAsyncController : ApiController
    {
        private readonly IFindText _findText;
        public TaskAsyncController()
        {
            _findText = new FindText();

        }

        public async Task<string> GetAsync()
        {
            await _findText.StudentNameAsync();
            return "str";
        }





    }
}
