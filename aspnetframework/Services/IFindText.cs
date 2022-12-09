using System.Threading.Tasks;
using System.Web.Mvc;

namespace aspnetframework.Services
{
    public interface IFindText
    {
        ActionResult FindTheWordMuch();
        string PropertyFromObject();
        string StudentToString();
       
    }
}
