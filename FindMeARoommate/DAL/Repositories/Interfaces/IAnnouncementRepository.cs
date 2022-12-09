using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.DAL.Repositories.Interfaces;

public interface IAnnouncementRepository
{
    Task<Announcement> AddAnnouncementAsync(Announcement announcement);
    Task<Announcement> UpdateAnnouncementAsync(Announcement announcement);
    Task<Announcement> DeleteAnnouncementAsync(int id);
    Task<Announcement> GetAnnouncementAsync(int id);
    Task<bool> ExistAsync(string Title, int RoomId);

}
