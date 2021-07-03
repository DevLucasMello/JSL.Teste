using JSL.Core.Data;
using JSL.Motorista.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Motorista.Data.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly MotoristaContext _context;

        public MotoristaRepository(MotoristaContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Domain.Motorista> ObterPorId(Guid id)
        {
            return await _context.Motoristas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Domain.Motorista>> ObterListaDeMotoristas()
        {
            return await _context.Motoristas.AsNoTracking().ToListAsync();
        }

        public void AdicionarMotorista(Domain.Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
        }

        public void AtualizarMotorista(Domain.Motorista motorista)
        {
            _context.Motoristas.Update(motorista);
        }        

        public void ExcluirMotorista(Domain.Motorista motorista)
        { 
            _context.Motoristas.Remove(motorista);
        } 

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
