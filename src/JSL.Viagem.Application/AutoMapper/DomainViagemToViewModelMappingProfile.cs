using AutoMapper;
using JSL.Viagem.Application.ViewModels;

namespace JSL.Viagem.Application.AutoMapper
{
    public class DomainViagemToViewModelMappingProfile : Profile
    {
        public DomainViagemToViewModelMappingProfile()
        {
            CreateMap<Domain.Viagem, ViagemViewModel>();
        }
    }
}
