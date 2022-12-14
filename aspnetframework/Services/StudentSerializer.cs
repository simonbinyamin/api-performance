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
    }
}
