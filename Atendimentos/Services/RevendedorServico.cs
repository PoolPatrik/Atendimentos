using Atendimentos.Data;
using Atendimentos.Models;
using Atendimentos.Services.Exeption;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Services
{
    public class RevendedorServico
    {
        private readonly AtendimentosContext _contexto;

        public RevendedorServico(AtendimentosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Revendedor>> ListarTudosAsync()
        {
            var a = _contexto.Revendedor.ToList();
            return await _contexto.Revendedor.ToListAsync();
        }

        public async Task<Revendedor> BuscaPorIdAsync(int id)
        {
            return await _contexto.Revendedor.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task IncluirAsync(Revendedor obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task ApagarAsync(int id)
        {
            try
            {
                var obj = await _contexto.Revendedor.FindAsync(id);
                _contexto.Revendedor.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception();
            }
        }

        public async Task EditarAsync(Revendedor obj)//tratar exceções 
        {
            bool hasAny = await _contexto.Revendedor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _contexto.Revendedor.Update(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}

