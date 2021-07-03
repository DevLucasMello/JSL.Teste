using AutoMapper;
using JSL.Motorista.Application.ViewModels;
using JSL.Motorista.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Motorista.Application.Services
{
    public class MotoristaAppService : IMotoristaAppService
    {
        private readonly IMotoristaRepository _motoristaRepository;        
        private readonly IMapper _mapper;

        public MotoristaAppService(IMotoristaRepository motoristaRepository, IMapper mapper)
        {
            _motoristaRepository = motoristaRepository;            
            _mapper = mapper;
        }

        public async Task<MotoristaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<MotoristaViewModel>(await _motoristaRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<MotoristaViewModel>> ObterListaDeMotoristas()
        {
            return _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ObterListaDeMotoristas());
        }

        public async Task AdicionarMotorista(MotoristaViewModel motoristaViewModel)
        {
            var motorista = _mapper.Map<Domain.Motorista>(motoristaViewModel);
            _motoristaRepository.AdicionarMotorista(motorista);

            await _motoristaRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarMotorista(MotoristaViewModel motoristaViewModel)
        {
            var motorista = _mapper.Map<Domain.Motorista>(motoristaViewModel);
            _motoristaRepository.AtualizarMotorista(motorista);

            await _motoristaRepository.UnitOfWork.Commit();
        }        

        public async Task ExcluirMotorista(MotoristaViewModel motoristaViewModel)
        {
            var motorista = _mapper.Map<Domain.Motorista>(motoristaViewModel);
            _motoristaRepository.ExcluirMotorista(motorista);

            await _motoristaRepository.UnitOfWork.Commit();
        }               

        public void Dispose()
        {
            _motoristaRepository?.Dispose();
        }
    }
}
