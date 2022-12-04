using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.BLL.Services.Interface
{
    public interface IStudentService
    {
        Task<Student> AddAsync(string name, string surname);

        Task<List<Student>> GetAllAsync();
    }
}
