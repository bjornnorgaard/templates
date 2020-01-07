using AutoMapper;

namespace Application.Features.Pet
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePet.Command, Models.Pet>().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<UpdatePet.Command, Models.Pet>();
        }
    }
}
