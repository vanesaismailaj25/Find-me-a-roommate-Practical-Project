using FindMeARoommate.DAL.Context;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindMeARoommate.DAL.Repositories.Implementation
{
    
    public class DormitoryRepository : IDormitoryRepository
    {
        protected FindMeARoomateContext _context;

        public DormitoryRepository(FindMeARoomateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Dormitory> AddDormitoryAsync(Dormitory dormitory)
        {
            var result = await _context.Dormitories.AddAsync(dormitory);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Dormitory> DeletedormitoryAsync(int id)
        {
            var entity = await GetDormitoryAsync(id);
            var result = _context.Dormitories.Remove(entity);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> ExistDormitoryAsync(string code, string Name)
        {
            var result = await _context.Dormitories.AnyAsync(s=> s.Code== code && s.Name == Name);

            return result;
        }

        public async Task<Dormitory> GetDormitoryAsync(int id)
        {
            var result = await _context.Dormitories.FirstOrDefaultAsync(d => d.Id == id);

            return result;
        }

        public async Task<Dormitory> UpdateDormitoryAsync(Dormitory dormitory)
        {
            var result = _context.Dormitories.Update(dormitory);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
