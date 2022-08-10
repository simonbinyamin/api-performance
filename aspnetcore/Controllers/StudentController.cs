using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        [HttpGet("GetStudents")]
        public string GetStudents()
        {
            return "sdad";

        }

        [HttpGet("FindText")]
        public string FindText()
        {
            return "sdad";

        }

        [HttpGet("ZipFiles")]
        public string ZipFiles()
        {
            return "sdad";

        }






    }
}
