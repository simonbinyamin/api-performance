
using common;
using System.Collections.Generic;
using System.Linq;

namespace aspnetframework.Services
{
    public class InMemoryFiltering: IInMemoryFiltering
    {
        public List<Student> data = new List<Student>() {
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=2, name="name2"},
                new Student { id=2, name="name3"},
                new Student { id=2, name="name4"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name2"},
                new Student { id=3, name="name3"},
                new Student { id=4, name="name4"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=2, name="name2"},
                new Student { id=2, name="name3"},
                new Student { id=2, name="name4"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name2"},
                new Student { id=3, name="name3"},
                new Student { id=4, name="name4"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=2, name="name2"},
                new Student { id=2, name="name3"},
                new Student { id=2, name="name4"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name2"},
                new Student { id=3, name="name3"},
                new Student { id=4, name="name4"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=1, name="name1"},
                new Student { id=2, name="name2"},
                new Student { id=2, name="name3"},
                new Student { id=2, name="name4"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name1"},
                new Student { id=3, name="name2"},
                new Student { id=3, name="name3"},
                new Student { id=4, name="name4"}
            };

        public List<Student> GetFilteredStudents()
        {
            return data.Where(student => student.id == 3).ToList();
        }

    }

   
}
