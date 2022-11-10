using System.Threading.Tasks;

namespace aspnetframework.Services
{
    public interface IFindText
    {
        string FindTheWordMuch();
        string ReplaceChar();
        string PropertyFromObject();
        string StudentToString();
        Task<string> StudentNameAsync();
    }
}
