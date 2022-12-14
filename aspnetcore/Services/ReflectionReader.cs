using Newtonsoft.Json.Linq;
using System.Net;
using System.Reflection;

namespace common
{
    public class ReflectionReader: IReflectionReader
    {
        private static string resultContent = String.Empty;
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
