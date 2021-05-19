using Atendimentos.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        [BindProperty, MaxLength(300)]
        public string Descrição { get; set; }
        public string Solucao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Date)]
        public DateTime HoraInicio{ get; set; }
        public DateTime HoraFim { get; set; }
        public string Ticket{ get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Revendedor Revendedor { get; set; }
        public int RevendedorId { get; set; }
        public Sistema Sistema { get; set; }
        public int SistemaId { get; set; }
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public AtendimentoStatus Status { get; set; }

        public Atendimento()
        {

        }

        public Atendimento(string descrição, string solucao, DateTime data, DateTime horaInicio, DateTime horaFim, string ticket, Usuario usuario, Revendedor revendedor, Sistema sistema, AtendimentoStatus status)
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
            Status = status;
        }

        public void AddComentario(Comentario comentario)
        {
            Comentarios.Add(comentario);
        }
    }
}
