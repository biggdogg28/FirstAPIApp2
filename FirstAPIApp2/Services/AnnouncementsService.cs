using FirstAPIApp2.DTOs;
using FirstAPIApp2.Repositories;

namespace FirstAPIApp2.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _repository;
        public AnnouncementsService(IAnnouncementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _repository.GetAnnouncementsAsync();
        }
    }
}
