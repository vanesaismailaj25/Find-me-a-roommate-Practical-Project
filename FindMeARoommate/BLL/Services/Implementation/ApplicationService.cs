using FindMeARoommate.BLL.Services.Interface;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Implementation;
using FindMeARoommate.DAL.Repositories.Interfaces;

namespace FindMeARoommate.BLL.Services.Implementation;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IAnnouncementRepository _announcementRepository;
    public ApplicationService(IApplicationRepository applicationRepository, IStudentRepository studentRepository, IAnnouncementRepository announcementRepository)
    {
        _applicationRepository = applicationRepository;
        _studentRepository = studentRepository;
        _announcementRepository = announcementRepository;
    }

    public async Task<Application> AddAsync(int studentId, int announcementId, DateTime dateTime, bool isActive)
    {
       var applicationExist = await _applicationRepository.ExistAsync(studentId, announcementId, dateTime, isActive);
        if (applicationExist)
        {
            throw new Exception("This application already exists!");
        }

        var application = new Application()
        {
            StudentId = studentId,
            AnnouncementId = announcementId,
            ApplicationDate= dateTime,
            IsActive = isActive
        };

        var result = await _applicationRepository.AddApplicationAsync(application);
        return result;
    }
}
