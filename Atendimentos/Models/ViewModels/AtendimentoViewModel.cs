using Atendimentos.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Models.ViewModels
{
    public class AtendimentoViewModel
    {
        public Atendimento Atendimento { get; set; }
        public ICollection<Sistema> Sistemas { get; set; }
        public ICollection<Revendedor> Revendedores { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }


    }
}
