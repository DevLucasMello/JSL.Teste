using JSL.Viagem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JSL.Viagem.Application.Services
{
    public interface IViagemAppService : IDisposable
    {
        Task<ViagemViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ViagemViewModel>> ObterViagensPorMotorista(Guid id);
        Task<IEnumerable<ViagemViewModel>> ObterListaDeViagens();
        Task AdicionarViagem(ViagemViewModel viagemViewModel);
        Task AtualizarViagem(ViagemViewModel viagemViewModel);
        Task ExcluirViagem(ViagemViewModel viagemViewModel);
    }
}
