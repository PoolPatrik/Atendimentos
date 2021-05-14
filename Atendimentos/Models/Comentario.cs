using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} obrigatorio")]
        public string Descrição { get; set; }
        public Atendimento Atendimento { get; set; }
        public int AtendimentoId { get; set; }

        public Comentario()
        {

        }
        public Comentario(string descrição, Atendimento atendimento, int atendimentoId)
        {
            Descrição = descrição;
            Atendimento = atendimento;
            AtendimentoId = atendimentoId;
        }
    }
}
