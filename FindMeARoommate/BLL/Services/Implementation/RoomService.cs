using FindMeARoommate.BLL.Services.Interface;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;

namespace FindMeARoommate.BLL.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public async Task<Room> AddAsync(int dormitoryId, string name, int capacity)
    {
        // Controll if room with this name exist for this dormitory
        var roomExist = await _roomRepository.ExistAsync(dormitoryId, name);
        if (roomExist)
        {
            throw new Exception("Room already exist");
        }

        var room = new Room
        {
            Capacity = capacity,
            Name = name,
            DormitoryId = dormitoryId
        };

        // Add room
        var result = await _roomRepository.AddRoomAsync(room);

        return result;
    }
}
