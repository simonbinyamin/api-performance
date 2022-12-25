using aspnetframework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public readonly IZipFiles _zipFiles;

        public ZipFilesController()
        {
            _zipFiles = new ZipFiles();
        }
        public string Get()
        {
            _zipFiles.CompressFiles();

            return "zipped";

        }

    }
}
