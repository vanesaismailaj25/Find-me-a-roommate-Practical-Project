using System;
using System.Collections.Generic;

namespace FindMeARoommate.DAL.Entities
{
    public partial class Room
    {
        public Room()
        {
            StudentRooms = new HashSet<StudentRoom>();
        }

        public int Id { get; set; }
        public int DormitoryId { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual Dormitory Dormitory { get; set; } = null!;
        public virtual ICollection<StudentRoom> StudentRooms { get; set; }
    }
}
