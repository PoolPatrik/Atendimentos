using Atendimentos.Data;
using Atendimentos.Models;
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
    }
}
