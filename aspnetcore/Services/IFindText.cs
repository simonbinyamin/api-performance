namespace aspnetcore.Services
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
