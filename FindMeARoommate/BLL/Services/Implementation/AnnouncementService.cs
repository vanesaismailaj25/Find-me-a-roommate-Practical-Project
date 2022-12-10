using FindMeARoommate.BLL.Services.Interface;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;

namespace FindMeARoommate.BLL.Services.Implementation;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IRoomRepository _roomReposiory;

    public AnnouncementService(IAnnouncementRepository announcementRepository, IRoomRepository roomRepository)
    {
        _announcementRepository = announcementRepository ?? throw new ArgumentNullException(nameof(announcementRepository));
        _roomReposiory= roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }
    public async Task<Announcement> AddAsync(string title, string description, int roomId)
    {
        var announcementExist =await  _announcementRepository.ExistAsync(title, roomId);
        if (announcementExist)
        {
            throw new Exception("This announcement alreaydy exists!");
        }

        var announcement = new Announcement()
        {
            Title = title,
            Description = description,
            RoomId = roomId

        };

        var result = await _announcementRepository.AddAnnouncementAsync(announcement);

        return result;


    }
}
