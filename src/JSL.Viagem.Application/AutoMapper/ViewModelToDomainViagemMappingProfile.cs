using AutoMapper;
using JSL.Viagem.Application.ViewModels;

namespace JSL.Viagem.Application.AutoMapper
{
    public class ViewModelToDomainViagemMappingProfile : Profile
    {
        public ViewModelToDomainViagemMappingProfile()
        {
            CreateMap<ViagemViewModel, Domain.Viagem>()
                .ConstructUsing(v => new Domain.Viagem(v.MotoristaId, v.DataHoraViajem, v.LocalEntrega, v.LocalSaida, v.Km));
        }
    }
}
