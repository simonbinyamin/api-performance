using common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace common
{
   public class StudentSerializer: IStudentSerializer
    {
        private static string resultContent = String.Empty;
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
                var studentString = JsonSerializer.Serialize(student);

                if (!string.IsNullOrEmpty(studentString))
                {
                    serializedstudent = studentString;
                }

            }

            return serializedstudent;

        }
    }
}
