using FindMeARoommate.DAL.Context;
using FindMeARoommate.DAL.Entities;
using FindMeARoommate.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindMeARoommate.DAL.Repositories.Implementation
{
    public class ApplicationRepository : IApplicationRepository
    {
        protected FindMeARoomateContext _context;

        public ApplicationRepository(FindMeARoomateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Application> AddApplicationAsync(Application application)
        {
            var result = await _context.Applications.AddAsync(application);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Application> DeleteApplicationAsync(int id)
        {
            var entity = await GetApplicationAsync(id);
            var result = _context.Applications.Remove(entity);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> ExistAsync(int StudentId, int AnnouncementId)
        {
            var result = await _context.Applications.AnyAsync(a => a.StudentId == StudentId && a.AnnouncementId==AnnouncementId);

            return result;
        }

        public async Task<Application> GetApplicationAsync(int id)
        {
            var result = await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);

            return result;

        }

        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            var result = _context.Applications.Update(application);
            _=await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
