using System;
using System.Collections.Generic;

namespace FindMeARoommate.DAL.Entities
{
    public partial class Student
    {
        public Student()
        {
            Applications = new HashSet<Application>();
            StudentRooms = new HashSet<StudentRoom>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<StudentRoom> StudentRooms { get; set; }
    }
}
