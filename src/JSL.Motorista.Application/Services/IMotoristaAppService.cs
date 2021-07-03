using JSL.Motorista.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Motorista.Application.Services
{
    public interface IMotoristaAppService : IDisposable
    {
        Task<MotoristaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<MotoristaViewModel>> ObterListaDeMotoristas();
        Task AdicionarMotorista(MotoristaViewModel motoristaViewModel);
        Task AtualizarMotorista(MotoristaViewModel motoristaViewModel);
        Task ExcluirMotorista(MotoristaViewModel motoristaViewModel);
    }
}
