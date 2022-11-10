using common;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace aspnetcore.Services
{
    public class FindText: IFindText
    {

        public FindText()
        {

        }
 

        public string FindTheWordMuch()
        {



            string? path = Path.GetPathRoot(Environment.SystemDirectory);


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

        public string StudentToString()
        {
            string serializedstudent = "";
            foreach (var student in students())
            {
                var studentString = JsonSerializer.Serialize(student);

                if (!string.IsNullOrEmpty(studentString))
                {
                    serializedstudent = studentString;
                }
            }
            return serializedstudent;
       
        }

        public string PropertyFromObject()
        {
            var studentsHashMap = students().ToDictionary(item => item.id,
                                       item => new { Property1 = item.id, Property2  = item.name});
            //
            string studentname = "";
            foreach (var entry in studentsHashMap)
            {
                PropertyInfo property = ((dynamic)entry.Value).GetType().GetProperty("Property1");
                var PropetyName = property.Name;
                var PropetyValue = ((dynamic)entry.Value).GetType().GetProperty(property.Name).GetValue(((dynamic)entry.Value), null);

                studentname = PropetyValue.ToString();
            }



            return studentname;
        }

        public string ReplaceChar()
        {
            string _str = "hello world from .NET!";
            _str.Replace(".", ",");
            return "sd";
        }

        public async Task<string> StudentNameAsync()
        {
            foreach (var student in students())
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string resultContent = "";

                    HttpResponseMessage response = await httpClient.GetAsync("https://randomuser.me/api/");


                    if (response.IsSuccessStatusCode)
                    {
                        resultContent = await response.Content.ReadAsStringAsync();
                    }

                    var json = JObject.Parse(resultContent);
                    var email = json?["results"]?[0]?["email"];

                    if (email!=null)
                    {
                        student.name = email.ToString();
                    }
                   
                    return resultContent;
                }
            }
            return "done";

        }

 



        private Student[] students()
        {
            var students = new Student[20000];
            for (int i = 0; i < 20000; i++)
            {
                students[i] = new Student
                {
                    id = i,
                    name = Guid.NewGuid().ToString()
                };

            }
            return students;
        }
    }
}
