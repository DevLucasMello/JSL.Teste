using AutoMapper;
using JSL.Viagem.Application.ViewModels;
using JSL.Viagem.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Viagem.Application.Services
{
    public class ViagemAppService : IViagemAppService
    {
        private readonly IViagemRepository _viagemRepository;
        private readonly IMapper _mapper;

        public ViagemAppService(IViagemRepository viagemRepository, IMapper mapper)
        {
            _viagemRepository = viagemRepository;
            _mapper = mapper;
        }

        public async Task<ViagemViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ViagemViewModel>(await _viagemRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ViagemViewModel>> ObterListaDeViagens()
        {
            return _mapper.Map<IEnumerable<ViagemViewModel>>(await _viagemRepository.ObterListaDeViagens());
        }

        public async Task AdicionarViagem(ViagemViewModel viagemViewModel)
        {
            var viagem = _mapper.Map<Domain.Viagem>(viagemViewModel);
            _viagemRepository.AdicionarViagem(viagem);

            await _viagemRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarViagem(ViagemViewModel viagemViewModel)
        {
            var viagem = _mapper.Map<Domain.Viagem>(viagemViewModel);
            _viagemRepository.AtualizarViagem(viagem);

            await _viagemRepository.UnitOfWork.Commit();
        }        

        public async  Task ExcluirViagem(ViagemViewModel viagemViewModel)
        {
            var viagem = _mapper.Map<Domain.Viagem>(viagemViewModel);
            _viagemRepository.ExcluirViagem(viagem);

            await _viagemRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _viagemRepository?.Dispose();
        }
    }
}
