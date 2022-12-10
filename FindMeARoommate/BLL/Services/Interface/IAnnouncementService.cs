using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.BLL.Services.Interface;

public interface IAnnouncementService
{
    Task<Announcement> AddAsync(string title, string description, int roomId);
}
