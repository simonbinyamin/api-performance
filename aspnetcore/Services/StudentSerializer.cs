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

        public List<string> StudentToString()
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

            var jobject = JObject.Parse(resultContent);

            JArray jarray = (JArray)jobject["results"];

            IList<Student> students = jarray.ToObject<IList<Student>>();

            List<string> serializedstudents = new List<string>();

            foreach (var student in students)
            {
                if (jobject != null)
                {
                    var studentString = JsonSerializer.Serialize(student);

                    if (!string.IsNullOrEmpty(studentString))
                    {
                        serializedstudent = studentString;
                    }

                }

                serializedstudents.Add(serializedstudent);

            }

            return serializedstudents;

        }
    }
}
