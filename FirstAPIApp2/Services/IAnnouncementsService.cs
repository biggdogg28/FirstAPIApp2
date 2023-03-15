using FirstAPIApp2.DTOs;

namespace FirstAPIApp2.Services
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();
    }
}
