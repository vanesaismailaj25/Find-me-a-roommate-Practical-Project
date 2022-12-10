using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.DAL.Repositories.Interfaces;

public interface IRoomRepository
{
    Task<Room> AddRoomAsync(Room room);
    Task<Room> UpdateRoomAsync(Room room);
    Task<Room> DeleteRoomAsync(int id);
    Task<Room> GetRoomAsync(int id);
    Task<bool> ExistAsync(int roomId);
    Task<bool> ExistAsync(int dormitoryId, string name);

}
