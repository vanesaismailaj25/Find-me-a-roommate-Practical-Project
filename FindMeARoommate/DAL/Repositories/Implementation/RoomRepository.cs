using FindMeARoommate.DAL.Context;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindMeARoommate.DAL.Repositories.Implementation
{
    public class RoomRepository : IRoomRepository
    {
        protected FindMeARoomateContext _context;

        public RoomRepository(FindMeARoomateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            var result = await _context.Rooms.AddAsync(room);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Room> DeleteRoomAsync(int id)
        {
            var entity = await GetRoomAsync(id);
            var result = _context.Rooms.Remove(entity);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> ExistAsync(int roomId)
        {
            var result = await _context.Rooms.AnyAsync(x => x.Id == roomId);
            return result;
        }

        public async Task<bool> ExistAsync(int dormitoryId, string name)
        {
            var result = await _context.Rooms.AnyAsync(r => r.DormitoryId == dormitoryId && r.Name == name);

            return result;
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            var result = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

            return result;
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            var result = _context.Rooms.Update(room);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
