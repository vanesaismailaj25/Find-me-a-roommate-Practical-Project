using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.BLL.Services.Interface;

public interface IDormitoryService
{
    Task<Dormitory> AddAsync(string code, string name, int capacity);
}
