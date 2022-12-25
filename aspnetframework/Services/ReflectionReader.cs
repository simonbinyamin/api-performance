using common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace aspnetframework.Services
{
    public class ReflectionReader: IReflectionReader
    {
        private static string resultContent = String.Empty;
        public Dictionary<int, string> PropertyFromObject()
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

            JArray jarray = (JArray)jobject["results"];

            IList<Student> students = jarray.ToObject<IList<Student>>();

            Dictionary<int, string> properties = new Dictionary<int, string>();

            for (int i = 0; i < students.Count; i++)
            {
                dynamic dynStudent = new
                {
                    name = students[i].name.ToString(),
                };
                PropertyInfo property = dynStudent.GetType().GetProperty("name");
                var propetyName = property.Name;
                var propetyValue = dynStudent.GetType().GetProperty(property.Name).GetValue(dynStudent, null);
                string propetyvaluestring = propetyValue.ToString();
                properties.Add(i, propetyvaluestring);
            }

            return properties;

        }
    }
}
