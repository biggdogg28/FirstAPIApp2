using FirstAPIApp2.DTOs;
using FirstAPIApp2.DataContext;
using Microsoft.EntityFrameworkCore;
using FirstAPIApp2.DTOs.CreateUpdateObjects;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using FirstAPIApp2.DTOs.PatchObjects;

namespace FirstAPIApp2.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        //const -> compile time, value needs to be assgined when we declare it
        //e.g. private const string name; --> will require a value to be declared

        //readonly -> runtime, value needs to be assgined in the constructor

        private readonly IMapper _mapper;

        public AnnouncementsRepository(ProgrammingClubDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            if (!await ExistAnnouncementAsync(id))
            {
                return null;
            }

            // oldfashioned way, instead use IMapper!!!
            //announcementFromDb.IDAnnouncement = id;
            //announcementFromDb.EventDate = announcement.EventDate;
            //announcementFromDb.Text = announcement.Text;
            //announcementFromDb.Title = announcement.Title;
            //announcementFromDb.ValidFrom = announcement.ValidFrom;
            //announcementFromDb.ValidTo = announcement.ValidTo;
            //announcementFromDb.Tags = announcement.Tags;

            var announcementUpdated = _mapper.Map<Announcement>(announcement);
            announcementUpdated.IDAnnouncement = id;

            _context.Announcements.Update(announcementUpdated);
            await _context.SaveChangesAsync();
            return announcement;
        }

        private async Task<bool> ExistAnnouncementAsync(Guid id)
        {
            return await _context.Announcements.CountAsync(a => a.IDAnnouncement == id) > 0;
        }

        public async Task<PatchAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, PatchAnnouncement announcement)
        {
            var announcementFromDb = await GetAnnouncementByIdAsync(id);

            if (announcementFromDb == null)
            {
                return null;
            }

            if(!string.IsNullOrEmpty(announcement.Title) && announcement.Title != announcementFromDb.Title) 
            {
                announcementFromDb.Title = announcement.Title;
            }
            if (!string.IsNullOrEmpty(announcement.Text) && announcement.Text != announcementFromDb.Title)
            {
                announcementFromDb.Text = announcement.Text;
            }
            if (!string.IsNullOrEmpty(announcement.Tags) && announcement.Tags != announcementFromDb.Tags)
            {
                announcementFromDb.Tags = announcement.Tags;
            }
            if (announcement.ValidFrom.HasValue && announcement.ValidFrom != announcementFromDb.ValidFrom)
            {
                announcementFromDb.ValidFrom = announcement.ValidFrom;
            }
            if (announcement.ValidTo.HasValue && announcement.ValidTo != announcementFromDb.ValidTo)
            {
                announcementFromDb.ValidTo = announcement.ValidTo;
            }
            if (announcement.EventDate.HasValue && announcement.EventDate != announcementFromDb.EventDate)
            {
                announcementFromDb.EventDate = announcement.EventDate;
            }

            _context.Announcements.Update(announcementFromDb);
            await _context.SaveChangesAsync();
            return announcement;
        }
    }
}
