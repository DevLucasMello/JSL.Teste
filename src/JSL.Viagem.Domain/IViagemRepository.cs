using JSL.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Viagem.Domain
{
    public interface IViagemRepository : IRepository<Viagem>
    {
        Task<Viagem> ObterPorId(Guid id);
        Task<IEnumerable<Viagem>> ObterListaDeViagens();
        Task<IEnumerable<Viagem>> ObterViagensPorMotorista(Guid id);
        void AdicionarViagem(Viagem viagem);
        void AtualizarViagem(Viagem viagem);
        void ExcluirViagem(Viagem viagem);
    }
}
