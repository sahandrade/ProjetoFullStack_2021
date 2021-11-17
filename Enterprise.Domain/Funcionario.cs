using System;

namespace Enterprise.Domain
{
    public class Funcionario
	{
		public Funcionario(int FuncionarioId, string Nome, string FotoUrl, string Rg, int DeptoId)
		{
			this.FuncionarioId = FuncionarioId;
			this.Nome = Nome;
			this.FotoUrl = FotoUrl;
			this.Rg = Rg;
			this.DeptoId = DeptoId;
		}
		
		public int FuncionarioId { get; set; }
		public string Nome { get; set; }
		public string FotoUrl {get; set; }
		public string Rg { get; set; }
		public int DeptoId { get; set;}
		public Depto Depto {get; set; }
	}
}
