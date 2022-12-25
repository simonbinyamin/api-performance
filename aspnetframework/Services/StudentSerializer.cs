using common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

                serializedstudents.Add(serializedstudent);

            }

            return serializedstudents;

        }
    }
}
