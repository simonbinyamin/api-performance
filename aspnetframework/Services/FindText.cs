using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;

namespace aspnetframework.Services
{
    public class FindText : IFindText
    {
        public ActionResult FindTheWordMuch()
        {
            try
            {
                HttpStatusCodeResult httpStatusCodeResult = null;
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
                Debug.WriteLine("My current thread is: " + Thread.CurrentThread.ManagedThreadId);
                return httpStatusCodeResult = new HttpStatusCodeResult(200, "Replaced");

            }
            catch (FileNotFoundException e)
            {
                return new HttpNotFoundResult();
            }

        }
    }
}
