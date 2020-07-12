using System;

namespace CH11_DRY
{
    public class Student : NotifyPropertyChanging
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
