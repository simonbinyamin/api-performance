using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace aspnetframework.Controllers
{
    public class ZipFilesController : ApiController
    {
        private readonly IZipFiles _zipFiles;

        public ZipFilesController()
        {
            _zipFiles = new ZipFiles();
        }
        public string GetAsync()
        {
           var t = _zipFiles.CompressFilesAsync();
            return "";
        }




    }
}
