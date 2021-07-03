using JSL.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Motorista.Domain
{
    public interface IMotoristaRepository : IRepository<Motorista>
    {
        Task<Motorista> ObterPorId(Guid id);
        Task<IEnumerable<Motorista>> ObterListaDeMotoristas();        
        void AdicionarMotorista(Motorista motorista);
        void AtualizarMotorista(Motorista motorista);
        void ExcluirMotorista(Motorista motorista);
    }
}
