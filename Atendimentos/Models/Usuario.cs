using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

        public Usuario()
        {

        }

        public Usuario(string nome)
        {
            Nome = nome;
        }

        public void AddAtendimento(Atendimento atendimento)
        {
            Atendimentos.Add(atendimento);
        }

        public double TotalAtendimentos(DateTime initial, DateTime final)
        {
            return Atendimentos.Where(atend => atend.Data >= initial && atend.Data <= final).Count();
        }
    }
}
