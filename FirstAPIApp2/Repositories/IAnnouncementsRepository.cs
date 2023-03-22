using FirstAPIApp2.DTOs;
using FirstAPIApp2.DTOs.CreateUpdateObjects;

namespace FirstAPIApp2.Repositories
{
    public interface IAnnouncementsRepository
    {
        // for async methods, we need to return Task - we need to use threading
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        public Task CreateAnnouncementAsync(Announcement announcement);
        public Task<bool> DeleteAnnouncementAsync(Guid id);
        public Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
        public Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
    }
}
