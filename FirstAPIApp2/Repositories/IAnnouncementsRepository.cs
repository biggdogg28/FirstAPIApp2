using FirstAPIApp2.DTOs;

namespace FirstAPIApp2.Repositories
{
    public interface IAnnouncementsRepository
    {
        // for async methods, we need to return Task - we need to use threading
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        public Task CreateAnnouncementAsync(Announcement announcement);
        public Task<bool> DeleteAnnouncementAsync(Guid id);
    }
}
