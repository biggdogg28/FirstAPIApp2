using AutoMapper;
using FirstAPIApp2.DTOs;
using FirstAPIApp2.DTOs.CreateUpdateObjects;

namespace FirstAPIApp2
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Announcement, CreateUpdateAnnouncement>().ReverseMap();
        }
    }
}
