using FindMeARoommate.DAL.Entities;

namespace FindMeARoommate.DAL.Repositories.Interfaces
{
    public interface IDormitoryRepository
    {
        Task<Dormitory> AddDormitoryAsync(Dormitory dormitory);
        Task<Dormitory> UpdateDormitoryAsync(Dormitory dormitory);
        Task<Dormitory> DeletedormitoryAsync(int id);
        Task<Dormitory> GetDormitoryAsync(int id);
        Task<List<Dormitory>> GetAllAsync();
        Task<bool> ExistDormitoryAsync(string Code, string Name);
    }
}
