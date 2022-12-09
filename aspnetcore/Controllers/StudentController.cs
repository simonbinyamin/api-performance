using aspnetcore.Services;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IInMemoryFiltering _inMemoryFiltering;
        private readonly IZipFiles _zipFiles;
        private readonly IFindText _findText;
        public StudentController(IInMemoryFiltering inMemoryFiltering, IZipFiles zipFiles, IFindText findText)
        {
            _inMemoryFiltering = inMemoryFiltering;
            _zipFiles = zipFiles;
            _findText = findText;
        }


        [HttpGet("Void")]
        public int Void() { return 0; }


        [HttpGet("GetStudents")]
        public List<Student> GetStudents()
        {
            var students = _inMemoryFiltering.GetFilteredStudents();
            return students;

        }

        [HttpGet("FindText")]
        public string FindText()
        {
            var res = _findText.FindTheWordMuch();
            return "sdad";

        }

        [HttpGet("ZipFiles")]
        public string ZipFiles()
        {
            var zipped = _zipFiles.CompressFiles();
            return "sdad";

        }


        [HttpGet("zxcxzcz")]
        public string ReplaceText()
        {
            var replace = _findText.ReplaceChar();
            return replace;

        }


        [HttpGet("ObjectReflection")]
        public string ObjectReflection()
        {
            var prop = _findText.PropertyFromObject();
            return prop;

        }


        [HttpGet("StudentSerializer")]
        public string StudentSerializer()
        {
            var student = _findText.StudentToString();
            return student;

        }

        [HttpGet("TaskAsync")]
        public async Task TaskAsync()
        {
            var r = await _findText.StudentNameAsync();
        }



    }
}
