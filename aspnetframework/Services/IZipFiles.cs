using System.Threading.Tasks;
using System.Web.Mvc;

namespace aspnetframework.Services
{
    public interface IZipFiles
    {
        Task<ActionResult> CompressFiles();
    }
}
