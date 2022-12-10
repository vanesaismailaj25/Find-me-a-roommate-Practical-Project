using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.BLL.Services.Interface;

public interface IApplicationService
{
    Task<Application> AddAsync(int studentId, int announcementId, DateTime dateTime, bool isActive);
}