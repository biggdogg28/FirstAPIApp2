using FirstAPIApp2.DTOs;

namespace FirstAPIApp2.Services
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        public Task CreateAnnouncementAsync(Announcement newAnnouncement);
        public Task<bool> DeleteAnnouncementAsync(Guid id);
    }
}
