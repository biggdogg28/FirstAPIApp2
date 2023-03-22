using FirstAPIApp2.DTOs;
using FirstAPIApp2.DTOs.CreateUpdateObjects;

namespace FirstAPIApp2.Services
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        public Task CreateAnnouncementAsync(Announcement newAnnouncement);
        public Task<bool> DeleteAnnouncementAsync(Guid id);
        public Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
        public Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
    }
}
