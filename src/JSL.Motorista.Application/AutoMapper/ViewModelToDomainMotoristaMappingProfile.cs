using AutoMapper;
using JSL.Motorista.Application.ViewModels;
using JSL.Motorista.Domain;

namespace JSL.Motorista.Application.AutoMapper
{
    public class ViewModelToDomainMotoristaMappingProfile : Profile
    {
        public ViewModelToDomainMotoristaMappingProfile()
        {
            CreateMap<MotoristaViewModel, Domain.Motorista>()
                .ConstructUsing(m => new Domain.Motorista(new Nome(m.PrimeiroNome, m.UltimoNome), new Caminhao(m.Marca, m.Modelo, m.Placa, m.Eixos), 
                new Endereco(m.Descricao, m.Logradouro, m.Numero, m.Bairro, m.Municipio, m.Estado, m.CEP)));
        }
    }
}
