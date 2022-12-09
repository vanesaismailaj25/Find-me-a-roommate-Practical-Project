using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;

namespace FindMeARoommate.DAL.Repositories.Implementation
{
    public class StudentRoomRepository : IStudentRoomRepository
    {
        public Task<StudentRoom> AddStudentRoom(StudentRoom studentRoom)
        {
            throw new NotImplementedException();
        }

        public Task<StudentRoom> DeleteStudentRoom(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int RoomId, int StudentId)
        {
            throw new NotImplementedException();
        }

        public Task<StudentRoom> GetStudentRoom(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentRoom> UpdateStudentRoom(StudentRoom studentRoom)
        {
            throw new NotImplementedException();
        }
    }
}
