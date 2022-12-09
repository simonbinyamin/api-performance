using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class InMemoryFiltering: IInMemoryFiltering
    {

        public List<Student> GetFilteredStudents()
        {
            var students = new List<Student>();

            if (students.Count == 0)
            {
                students = GenerateRandomStudents();
            }

            students.Sort(
                delegate (Student p1, Student p2)
                {
                    return p1.score.CompareTo(p2.score);
                }
            );


       



            int highestScore = students[students.Count - 1].score;
            var studentsHighestScore = new List<Student>();

            for (int i = students.Count - 1; i > 0; i--)
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

        private List<Student> GenerateRandomStudents()
        {
            var students = new Student[100];
            for (int i = 0; i < 100; i++)
            {
                students[i] = new Student
                {
                    id = i,
                    name = Guid.NewGuid().ToString(),
                    score = new Random().Next(1,99)
                };

            }
            return students.ToList();
        }

    }

   
}
