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
    }
}
