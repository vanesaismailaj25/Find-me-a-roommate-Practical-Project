using FindMeARoommate.DAL.Context;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindMeARoommate.DAL.Repositories.Implementation
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        protected FindMeARoomateContext _context;

        public AnnouncementRepository(FindMeARoomateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Announcement> AddAnnouncementAsync(Announcement announcement)
        {
           var result = await _context.Announcements.AddAsync(announcement);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Announcement> DeleteAnnouncementAsync(int id)
        {
            var entity = GetAnnouncementAsync(id);
            var result = await _context.Announcements.Remove(entity);

            return result.Entity;
        }

        public Task<bool> ExistAsync(string Title, int RoomId)
        {
            throw new NotImplementedException();
        }

        public async Task<Announcement> GetAnnouncementAsync(int id)
        {
            var result = await _context.Announcements.FirstOrDefaultAsync(a=> a.Id == id);

            return result;
        }

        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            var result =  _context.Announcements.Update(announcement);
            _ = await _context.SaveChangesAsync();
            
            return result.Entity;
        }
    }
}
