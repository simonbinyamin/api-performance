using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetframework.Services
{
    public interface IStudentSerializer
    {
        List<string> StudentToString();
    }
}
