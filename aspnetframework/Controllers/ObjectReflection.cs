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
    public class ObjectReflectionController : ApiController
    {
        private readonly IReflectionReader _reflectionReader;
        public ObjectReflectionController()
        {
            _reflectionReader = new ReflectionReader();

        }

        public Dictionary<int, string> Get()
        {
            var props = _reflectionReader.PropertyFromObject();
            return props;
        }






    }
}
