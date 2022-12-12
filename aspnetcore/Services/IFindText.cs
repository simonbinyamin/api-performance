using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.Services
{
    public interface IFindText
    {
        ActionResult FindTheWordMuch();
        string PropertyFromObject();
        string StudentToString();

    }
}
