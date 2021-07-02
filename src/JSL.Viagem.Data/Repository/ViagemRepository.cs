using JSL.Core.Data;
using JSL.Viagem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.Viagem.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly ViagemContext _context;

        public ViagemRepository(ViagemContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Domain.Viagem> ObterPorId(Guid id)
        {
            return await _context.Viagens.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Viagem>> ObterListaDeViagens()
        {
            return await _context.Viagens.AsNoTracking().ToListAsync();
        }

        public void AdicionarViagem(Domain.Viagem viagem)
        {
            _context.Viagens.Add(viagem);
        }

        public void AtualizarViagem(Domain.Viagem viagem)
        {
            _context.Viagens.Update(viagem);
        }        

        public async void ExcluirViagem(Guid viagemId)
        {
            var viagem = await _context.Viagens.FirstOrDefaultAsync(v => v.Id == viagemId);            

            _context.Viagens.Remove(viagem);
        }              

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
