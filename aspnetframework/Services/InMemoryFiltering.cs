
using common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnetframework.Services
{
    public class InMemoryFiltering: IInMemoryFiltering
    {


        public List<Student> GetFilteredStudents()
        {
            var reversed = students().Reverse().ToList();


            reversed.Sort(
                delegate (Student p1, Student p2)
                {
                    return p1.id.CompareTo(p2.id);
                }
            );


            return reversed;

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
