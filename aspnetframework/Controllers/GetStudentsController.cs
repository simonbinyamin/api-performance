using aspnetframework.Services;
using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class GetStudentsController : ApiController
    {
        private readonly IInMemoryFiltering _inMemoryFiltering;
        private readonly IFindText _findText;
        private readonly IZipFiles _zipFiles;
        public GetStudentsController()
        {
            _inMemoryFiltering = new InMemoryFiltering();
            _zipFiles = new ZipFiles();
            _findText = new FindText();
        }
        public string Get()
        {
            //var tB = _inMemoryFiltering.GetFilteredStudents();
            // var t = _findText.FindTheWordMuch();
            //var obj = _findText.PropertyFromObject();
            //var repl = _findText.ReplaceChar();
            //var str = _findText.StudentToString();
            _zipFiles.CompressFiles();
            return "value";
        }
    }
}
