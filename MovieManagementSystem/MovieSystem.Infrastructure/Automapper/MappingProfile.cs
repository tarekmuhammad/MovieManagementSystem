using AutoMapper;
 

namespace MovieSystem.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Commen.Users,Presistance.Models.ApplicationUser>()
                .ReverseMap();
        }
    }
}
