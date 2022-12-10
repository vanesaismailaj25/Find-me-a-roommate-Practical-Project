using FindMeARoommate.BLL.Services.Interface;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;

namespace FindMeARoommate.BLL.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
    }

    public async Task<Student> AddAsync(string name, string surname)
    {
        //throw new NotImplementedException();
        //Get informantion from user, name and surname,

        // Check if the student exist
        if (await _studentRepository.ExistAsync(name, surname))
        {
            throw new Exception("This user already exists!");

        }
        // Save user in database

        var student = new Student()
        {
            Name = name,
            Surname = surname

        };
        var result = await _studentRepository.AddAsync(student);

        // Return saved user

        return result;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        var result = await _studentRepository.GetAsync();
        return result;
    }
}
