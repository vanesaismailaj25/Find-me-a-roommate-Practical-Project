using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.BLL.Services.Interface;

public interface IRoomService
{
    Task<Room> AddAsync(int dormitoryId, string name, int capacity);
}
