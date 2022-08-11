using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnetframework.Controllers
{
    public class ZipFilesController : ApiController
    {
        private readonly IZipFiles _zipFiles;

        public ZipFilesController()
        {
            _zipFiles = new ZipFiles();
        }
        public string Get()
        {
            _zipFiles.CompressFiles();
            return "value3";
        }




    }
}
