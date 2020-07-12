using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CH11_DRY
{
    public class Demo
    {
        private BindingList<Student> _students;

        public Demo()
        {
            _students = new BindingList<Student>();
            _students.ListChanged += Students_ListChanged;
            AddStudents();
            var student = _students.ElementAt(0);
            Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}");
            student.LastName = "Four";
        }

        private void Students_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null)
                return;
            var student = _students.ElementAt(e.NewIndex);
            Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}");
        }

        private void AddStudents()
        {
            _students.Add(
                new Student { Id = Guid.NewGuid(), FirstName = "Student", LastName = "One" }
            );
            _students.Add(
                new Student { Id = Guid.NewGuid(), FirstName = "Student", LastName = "Two" }
            );
            _students.Add(
                new Student { Id = Guid.NewGuid(), FirstName = "Student", LastName = "Three" }
            );
        }
    }
}
