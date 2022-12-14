using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace aspnetcore.Services
{
    public class FindText: IFindText
    {
        public ActionResult FindTheWordMuch()
        {
            try
            {

                string line;
                string word;
                string filePath = AppDomain.CurrentDomain.BaseDirectory;

                using (StreamReader streamReader = new StreamReader(filePath + "huge.txt", Encoding.UTF8))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {

                        int index = line.IndexOf("Much");

                        if (index != -1)
                        {
                            word = line.Substring(index, 5);
                            if (!string.IsNullOrEmpty(word))
                            {
                                word.Replace(".", ",");
                                break;
                            }
                        }

                    }
                }

       
                return new StatusCodeResult(200);
            }
            catch (FileNotFoundException)
            {
                return new NotFoundResult();
            }

        }
    }
}
