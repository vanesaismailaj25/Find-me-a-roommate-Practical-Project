using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.DAL.Repositories.Interfaces;

public interface IStudentRoomRepository
{
    Task<StudentRoom> AddStudentRoom(StudentRoom studentRoom);
    Task<StudentRoom> UpdateStudentRoom(StudentRoom studentRoom);
    Task<StudentRoom> DeleteStudentRoom(int Id);
    Task<StudentRoom> GetStudentRoom(int Id);
    Task<bool> ExistAsync(int RoomId,int StudentId );
}
