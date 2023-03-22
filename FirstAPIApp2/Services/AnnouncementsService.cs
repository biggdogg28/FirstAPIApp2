using FirstAPIApp2.DTOs;
using FirstAPIApp2.DTOs.CreateUpdateObjects;
using FirstAPIApp2.DTOs.PatchObjects;
using FirstAPIApp2.Helpers;
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

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _repository.GetAnnouncementByIdAsync(id);
        }

        public async Task CreateAnnouncementAsync(Announcement newAnnouncement)
        {
            // validation is usually added to the business layer (Services)
            ValidationFunctions.ExceptionWhenDateIsNotValid(newAnnouncement.ValidFrom, newAnnouncement.ValidTo);

            await _repository.CreateAnnouncementAsync(newAnnouncement);

        }

        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            return await _repository.DeleteAnnouncementAsync(id);
        }

        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            ValidationFunctions.ExceptionWhenDateIsNotValid(announcement.ValidFrom, announcement.ValidTo);

            return await _repository.UpdateAnnouncementAsync(id, announcement);
        }

        public async Task<PatchAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, PatchAnnouncement announcement)
        {
            ValidationFunctions.ExceptionWhenDateIsNotValid(announcement.ValidFrom, announcement.ValidTo);

            return await _repository.UpdatePartiallyAnnouncementAsync(id, announcement);
        }
    }
}
