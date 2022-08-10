using System.IO;
using System.Text;

namespace aspnetcore.Services
{
    public class FindText: IFindText
    {
        public string FindTheWordMuch()
        {
            string readContents;
            using (StreamReader streamReader = new StreamReader(@"c:\testcase\huge.txt", Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }
            if (readContents.Contains("Much") == true)
            {
                return "Found";
            }
            else
            {
                return "Not found";
            }

        }
    }
}
