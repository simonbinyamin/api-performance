using common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace aspnetframework.Services
{
    public class FindText : IFindText
    {


        private static string resultContent = String.Empty;
        public FindText()
        {

        }

        public ActionResult FindTheWordMuch()
        {
            try
            {
                HttpStatusCodeResult httpStatusCodeResult = null;
                string line;
                string word;

                using (StreamReader streamReader = new StreamReader(@"c:\testcase\huge.txt", Encoding.UTF8))
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

                return httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.OK, "Replaced");
            }
            catch (FileNotFoundException)
            {
                return new HttpNotFoundResult();
            }

        }




        public string StudentToString()
        {

            if (string.IsNullOrEmpty(resultContent))
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:3333/Data/Studentjson");
                request.Method = "GET";
                request.ContentType = "application/json";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    resultContent = reader.ReadToEnd();

                    reader.Close();
                    dataStream.Close();
                }

            }

            string serializedstudent = "";
            Student student;


            var jobject = JObject.Parse(resultContent);
            var getName = jobject?["results"]?["name"];
            var getEmail = jobject?["results"]?["email"];

            student = new Student
            {
                email = getEmail.ToString(),
                name = getName.ToString(),

            };

            if (jobject != null)
            {

                string studentString = "";
                using (var ms = new MemoryStream())
                {
                    DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(Student));
                    serialiser.WriteObject(ms, student);
                    byte[] json = ms.ToArray();
                    studentString = Encoding.UTF8.GetString(json, 0, json.Length);
                }

                if (!string.IsNullOrEmpty(studentString))
                {
                    serializedstudent = studentString;
                }

            }

            return serializedstudent;






        }


        public string PropertyFromObject()
        {
            if (string.IsNullOrEmpty(resultContent))
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:3333/Data/Studentjson");
                request.Method = "GET";
                request.ContentType = "application/json";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    resultContent = reader.ReadToEnd();

                    reader.Close();
                    dataStream.Close();
                }

            }

            var jobject = JObject.Parse(resultContent);
            var getName = jobject?["results"]?["name"];


            dynamic student = new
            {
                name = getName.ToString(),

            };

            PropertyInfo property = student.GetType().GetProperty("name");
            var PropetyName = property.Name;
            var PropetyValue = student.GetType().GetProperty(property.Name).GetValue(student, null);
            return PropetyValue.ToString();

  
        }

        





    }
}
