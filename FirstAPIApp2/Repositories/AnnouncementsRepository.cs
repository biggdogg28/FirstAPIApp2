using FirstAPIApp2.DTOs;
using FirstAPIApp2.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp2.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        //const -> compile time, value needs to be assgined when we declare it
        //e.g. private const string name; --> will require a value to be declared

        //readonly -> runtime, value needs to be assgined in the constructor

        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _context.Announcements.SingleOrDefaultAsync(a => a.IDAnnouncement == id);
        }

        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            announcement.IDAnnouncement = Guid.NewGuid();
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            Announcement announcement = await GetAnnouncementByIdAsync(id);
            if (announcement == null) 
            {
                return false;
            }
            _context.Announcements.Remove(announcement);
            _context.SaveChanges();
            return true;
        }
    }
}
