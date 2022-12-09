using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.DAL.Repositories.Interfaces;

public interface IApplicationRepository
{
    Task<Application> AddApplicationAsync(Application application);
    Task<Application> UpdateApplicationAsync(Application application);
    Task<Application> DeleteApplicationAsync(int id);
    Task<Application> GetApplicationAsync(int id);
    Task<bool> ExistAsync(int StudentId, int AnnouncementId);

}
