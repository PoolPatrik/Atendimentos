using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atendimentos.Models
{
    public class Revendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} obrigatorio")]
        public string Nome { get; set; }
        public ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

        public Revendedor()
        {

        }

        public Revendedor(string nome)
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
