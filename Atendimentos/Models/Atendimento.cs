using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public string Descrição { get; set; }
        public string Solucao { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicio{ get; set; }
        public DateTime HoraFim { get; set; }
        public string Ticket{ get; set; }
        public Usuario Usuario { get; set; }
        public Revendedor Revendedor { get; set; }
        public Sistema Sistema { get; set; }

        public Atendimento(string descrição, string solucao, DateTime data, DateTime horaInicio, DateTime horaFim, string ticket, Usuario usuario, Revendedor revendedor, Sistema sistema)
        {
            Descrição = descrição;
            Solucao = solucao;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Ticket = ticket;
            Usuario = usuario;
            Revendedor = revendedor;
            Sistema = sistema;
        }
    }
}
