using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public interface IReflectionReader
    {
        Dictionary<int, string> PropertyFromObject();
    }
}
