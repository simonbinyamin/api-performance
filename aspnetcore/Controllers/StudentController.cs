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
        private readonly IStudentSerializer _studentSerializer;
        private readonly IReflectionReader _reflectionReader;

        public StudentController(IInMemoryFiltering inMemoryFiltering, IZipFiles zipFiles, IFindText findText, IStudentSerializer studentSerializer, IReflectionReader reflectionReader)
        {
            _inMemoryFiltering = inMemoryFiltering;
            _zipFiles = zipFiles;
            _findText = findText;
            _studentSerializer = studentSerializer;
            _reflectionReader = reflectionReader;
        }


        [HttpGet("Empty")]
        public bool Empty() { return true; }


        [HttpGet("GetStudents")]
        public List<Student> GetStudents()
        {
            var students = _inMemoryFiltering.GetFilteredStudents();
            return students;

        }

        [HttpGet("FindText")]
        public string FindText()
        {
            _findText.FindTheWordMuch();
            return "Replaced";

        }

        [HttpGet("ZipFiles")]
        public string ZipFiles()
        {
            _zipFiles.CompressFiles();
            return "Created";

        }


        [HttpGet("ObjectReflection")]
        public string ObjectReflection()
        {
            var prop = _reflectionReader.PropertyFromObject();
            return prop;

        }


        [HttpGet("StudentSerializer")]
        public string StudentSerializer()
        {
            var student = _studentSerializer.StudentToString();
            return student;

        }




    }
}
