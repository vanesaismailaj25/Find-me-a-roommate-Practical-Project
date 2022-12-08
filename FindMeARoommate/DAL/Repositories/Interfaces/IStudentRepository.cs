using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        //ose me student ose me string name dhe surname
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(int studentId);
        //dy metodat e fundit jane te ngajshme vecse njera merr 1 student tjetra merr nje liste me student
        Task<Student> GetAsync(int studentId);
        Task<List<Student>> GetAsync();

        Task<bool> ExistAsync(string name, string surname);
    }
