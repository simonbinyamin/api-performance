using aspnetcore.Services;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IInMemoryFiltering _inMemoryFiltering;
        private readonly IZipFiles _zipFiles;
        public StudentController(IInMemoryFiltering inMemoryFiltering, IZipFiles zipFiles)
        {
            _inMemoryFiltering = inMemoryFiltering;
            _zipFiles = zipFiles;
        }
        [HttpGet("GetStudents")]
        public List<Student> GetStudents()
        {
            var students = _inMemoryFiltering.GetFilteredStudents();
            return students;

        }

        [HttpGet("FindText")]
        public string FindText()
        {
            return "sdad";

        }

        [HttpGet("ZipFiles")]
        public string ZipFiles()
        {
            var zipped = _zipFiles.CompressFiles();
            return "sdad";

        }






    }
}
