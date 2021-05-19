using Atendimentos.Data;
using Atendimentos.Models;
using Atendimentos.Services.Exeption;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atendimentos.Models.Enums;

namespace Atendimentos.Services
{
    public class AtendimentoServico
    {
        private readonly AtendimentosContext _contexto;

        public AtendimentoServico(AtendimentosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Atendimento>> ListarTudosAsync()
        {
            //return await _contexto.Atendimento.ToListAsync();
            return await _contexto.Atendimento.Where(obj => obj.Status == AtendimentoStatus.Iniciado || obj.Status == AtendimentoStatus.Aberto).Include(obj => obj.Revendedor).Include(obj => obj.Sistema).ToListAsync();
        }

        public async Task<Atendimento> BuscaPorIdAsync(int id)
        {
            return await _contexto.Atendimento.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task IncluirAsync(Atendimento obj)
        {
            obj.Data = DateTime.Now;
            obj.HoraInicio = DateTime.Now;

            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task ApagarAsync(int id)
        {
            try
            {
                var obj = await _contexto.Atendimento.FindAsync(id);
                _contexto.Atendimento.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception();
            }
        }

        public async Task EditarAsync(Atendimento obj, bool finalizar)//tratar exceções 
        {
            if(finalizar)
            {
                obj.Status = AtendimentoStatus.Finalizado;
                obj.HoraFim = DateTime.Now;
            }
            bool hasAny = await _contexto.Atendimento.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _contexto.Atendimento.Update(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}

