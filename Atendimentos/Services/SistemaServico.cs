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
    public class SistemaServico
    {
        private readonly AtendimentosContext _contexto;

        public SistemaServico(AtendimentosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Sistema>> ListarTudosAsync()
        {
            var a = _contexto.Sistema.ToList();
            return await _contexto.Sistema.ToListAsync();
        }

        public async Task<Sistema> BuscaPorIdAsync(int id)
        {
            return await _contexto.Sistema.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task IncluirAsync(Sistema obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task ApagarAsync(int id)
        {
            try
            {
                var obj = await _contexto.Sistema.FindAsync(id);
                _contexto.Sistema.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception();
            }
        }

        public async Task EditarAsync(Sistema obj)//tratar exceções 
        {
            bool hasAny = await _contexto.Sistema.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");

            }
            try
            {
                _contexto.Sistema.Update(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
