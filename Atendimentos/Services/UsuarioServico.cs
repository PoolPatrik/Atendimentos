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
    public class UsuarioServico
    {
        private readonly AtendimentosContext _contexto;

        public UsuarioServico(AtendimentosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Usuario>> ListarTudosAsync()
        {
            var a = _contexto.Usuario.ToList();
            return await _contexto.Usuario.ToListAsync();
        }

        public async Task<Usuario> BuscaPorIdAsync(int id)
        {
            return await _contexto.Usuario.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task IncluirAsync(Usuario obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task ApagarAsync(int id)
        {
            try
            {
                var obj = await _contexto.Usuario.FindAsync(id);
                _contexto.Usuario.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception();
            }
        }

        public async Task EditarAsync(Usuario obj)//tratar exceções 
        {
            bool hasAny = await _contexto.Usuario.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _contexto.Usuario.Update(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}

