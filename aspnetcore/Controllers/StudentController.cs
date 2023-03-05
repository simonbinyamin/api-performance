using aspnetcore.Services;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace aspnetcore.Controllers
{
    public class AboutModel
    {
        public string error { get; set; }
    }
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly IInMemoryFiltering _inMemoryFiltering;
        private readonly IZipFiles _zipFiles;
        private readonly IFindText _findText;
        private readonly IStudentSerializer _studentSerializer;
        private readonly IReflectionReader _reflectionReader;

        public StudentController(ILogger<AboutModel> logger, IInMemoryFiltering inMemoryFiltering, IZipFiles zipFiles, IFindText findText, IStudentSerializer studentSerializer, IReflectionReader reflectionReader)
        {
            _inMemoryFiltering = inMemoryFiltering;
            _zipFiles = zipFiles;
            _findText = findText;
            _studentSerializer = studentSerializer;
            _reflectionReader = reflectionReader;
            _logger = logger;
        }
        [HttpGet("Empty")]
        public string Empty()
        {

            return "My current thread is: " + Thread.CurrentThread.ManagedThreadId;



        }


        [HttpGet("GetStudents")]
        public string GetStudents()
        {
            var students = _inMemoryFiltering.GetFilteredStudents();



            return "My current thread is: " + Thread.CurrentThread.ManagedThreadId;

        }

        [HttpGet("FindText")]
        public string FindText()
        {

            _findText.FindTheWordMuch();





            return "My current thread is: " + Thread.CurrentThread.ManagedThreadId;

        }

        [HttpGet("ZipFiles")]
        public string ZipFiles()
        {
            _zipFiles.CompressFiles();



            return "My current thread is: " + Thread.CurrentThread.ManagedThreadId;

        }


        [HttpGet("ObjectReflection")]
        public string ObjectReflection()
        {
            var props = _reflectionReader.PropertyFromObject();




            return "My current thread is: " + Thread.CurrentThread.ManagedThreadId;

        }


        [HttpGet("StudentSerializer")]
        public string StudentSerializer()
        {

            var students = _studentSerializer.StudentToString();




            return "My current thread is: " + Thread.CurrentThread.ManagedThreadId;

        }



        //[HttpGet("Empty")]
        //public bool Empty() {

        //    //"My current thread is: " + Thread.CurrentThread.ManagedThreadId

        //    return true;
        //}


        //[HttpGet("GetStudents")]
        //public List<Student> GetStudents()
        //{
        //    var students = _inMemoryFiltering.GetFilteredStudents();



        //    return students;

        //}

        //[HttpGet("FindText")]
        //public string FindText()
        //{

        //    _findText.FindTheWordMuch();





        //    return "Found";

        //}

        //[HttpGet("ZipFiles")]
        //public string ZipFiles()
        //{
        //    _zipFiles.CompressFiles();



        //    return "zipped";

        //}


        //[HttpGet("ObjectReflection")]
        //public Dictionary<int, string> ObjectReflection()
        //{
        //    var props = _reflectionReader.PropertyFromObject();




        //    return props;

        //}


        //[HttpGet("StudentSerializer")]
        //public List<string> StudentSerializer()
        //{

        //    var students = _studentSerializer.StudentToString();




        //    return students;

        //}




    }
}
