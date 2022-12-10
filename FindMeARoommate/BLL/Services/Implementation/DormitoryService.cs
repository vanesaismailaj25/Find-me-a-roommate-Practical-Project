using FindMeARoommate.BLL.Services.Interface;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace FindMeARoommate.BLL.Services.Implementation;

public class DormitoryService : IDormitoryService
{
    private readonly IDormitoryRepository _dormitoryRepository;

    public DormitoryService(IDormitoryRepository dormitoryRepository)
    {
        _dormitoryRepository = dormitoryRepository ?? throw new ArgumentNullException(nameof(dormitoryRepository));
    }

    public async Task<Dormitory> AddAsync(string code, string name, int capacity)
    {
        var dormitoryExist = await _dormitoryRepository.ExistDormitoryAsync(code, name);
        if(dormitoryExist)
        {
            throw new Exception("Dormitory already exists!");
        }

        var dormitory = new Dormitory()
        {
            Code = code,
            Name = name,
            MaxCapacity = capacity
        };

        var result = await _dormitoryRepository.AddDormitoryAsync(dormitory);

        return result;
    }

}
