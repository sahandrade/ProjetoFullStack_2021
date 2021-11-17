using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enterprise.Domain
{
    public class Depto
    {
        public Depto(int DeptoId, string Nome, string Sigla)
		{
			this.DeptoId = DeptoId;
			this.Nome = Nome;
			this.Sigla = Sigla;
		}

		public int DeptoId { get; set; }
		public string Nome { get; set; }
		public string Sigla { get; set; }
		public ICollection<Funcionario> Funcionarios { get;} = new List<Funcionario>();
    }
}