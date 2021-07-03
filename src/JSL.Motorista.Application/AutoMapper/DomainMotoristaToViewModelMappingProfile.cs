using AutoMapper;
using JSL.Motorista.Application.ViewModels;

namespace JSL.Motorista.Application.AutoMapper
{
    public class DomainMotoristaToViewModelMappingProfile : Profile
    {
        public DomainMotoristaToViewModelMappingProfile()
        {
            CreateMap<Domain.Motorista, MotoristaViewModel>()
                .ForMember(n => n.PrimeiroNome, m => m.MapFrom(m => m.Nome.PrimeiroNome))
                .ForMember(n => n.UltimoNome, m => m.MapFrom(m => m.Nome.UltimoNome))
                .ForMember(n => n.Marca, m => m.MapFrom(c => c.Caminhao.Marca))
                .ForMember(n => n.Modelo, m => m.MapFrom(c => c.Caminhao.Modelo))
                .ForMember(n => n.Placa, m => m.MapFrom(c => c.Caminhao.Placa))
                .ForMember(n => n.Eixos, m => m.MapFrom(c => c.Caminhao.Eixos))
                .ForMember(n => n.Descricao, m => m.MapFrom(e => e.Endereco.Descricao))
                .ForMember(n => n.Logradouro, m => m.MapFrom(e => e.Endereco.Logradouro))
                .ForMember(n => n.Numero, m => m.MapFrom(e => e.Endereco.Numero))
                .ForMember(n => n.Bairro, m => m.MapFrom(e => e.Endereco.Bairro))
                .ForMember(n => n.Municipio, m => m.MapFrom(e => e.Endereco.Municipio))
                .ForMember(n => n.Estado, m => m.MapFrom(e => e.Endereco.Estado))
                .ForMember(n => n.CEP, m => m.MapFrom(e => e.Endereco.CEP));
        }
    }
}
