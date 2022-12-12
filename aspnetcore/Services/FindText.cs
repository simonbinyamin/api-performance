﻿using common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace aspnetcore.Services
{
    public class FindText: IFindText
    {
        private static string resultContent = String.Empty;
        public FindText()
        {

        }
 


        public ActionResult FindTheWordMuch()
        {
            try
            {

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

                return new OkResult();
            }
            catch (FileNotFoundException)
            {
                return new NotFoundResult();
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
