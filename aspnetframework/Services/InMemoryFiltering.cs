
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
           Student[] students = new Student[] {};

            if (students.Length == 0)
            {
                students = GenerateRandomStudents();
            }

            Array.Sort(students, delegate (Student user1, Student user2) {
                return user1.score.CompareTo(user2.score);
            });

            int highestScore = students[students.Length - 1].score;
            var studentsHighestScore = new List<Student>();

            for (int i = students.Length - 1; i > 0; i--)
            {
                if (students[i].score == highestScore)
                {
                    studentsHighestScore.Add(students[i]);
                }
                else
                {
                    break;
                }
            }

            return studentsHighestScore;

        }

        private Student[] GenerateRandomStudents()
        {
            var students = new Student[100];
            for (int i = 0; i < 100; i++)
            {
                students[i] = new Student
                {
                    id = i,
                    name = Guid.NewGuid().ToString(),
                    score = i+1
                };

            }
            return students;
        }


    }

   
}
