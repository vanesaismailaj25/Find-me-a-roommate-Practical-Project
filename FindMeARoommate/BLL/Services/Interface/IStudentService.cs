using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.BLL.Services.Interface
{
    public interface IStudentService
    {
        Task<Student> AddAssync(string name, string surname);

        Task<Student> GetAllAsync();
    }
}
