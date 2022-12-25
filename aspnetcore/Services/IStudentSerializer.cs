using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public interface IStudentSerializer
    {
        List<string> StudentToString();
    }
}
