using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atendimentos.Models;

namespace Atendimentos.Data
{
    public class AtendimentosContext : DbContext
    {
        public AtendimentosContext (DbContextOptions<AtendimentosContext> options)
            : base(options)
        {
        }

        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Sistema> Sistema { get; set; }

    }
}
