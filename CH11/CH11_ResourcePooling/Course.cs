using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_ResourcePooling
{
    public class Course
    {
        public Dictionary<int, string> Students { get; set; }

        public Course()
        {
            Students = new Dictionary<int, string>();
            for (var i = 1; i <= 1000000; i++)
            {
                Students.Add(i, $"Student Number{i}");
            }
        }

        public string GetStudentById(int id)
        {
            return Students.Where(k => k.Key == id).FirstOrDefault().Value;
        }
    }
}
