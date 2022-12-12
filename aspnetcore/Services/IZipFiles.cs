using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.Services
{
    public interface IZipFiles
    {
        Task<ActionResult> CompressFilesAsync();
    }
}
