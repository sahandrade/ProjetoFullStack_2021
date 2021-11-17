using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Enterprise.Domain;

namespace Enterprise.Application.Dtos
{
    public class DeptoDto
    {
        public int DeptoId { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigtório."),
        StringLength(50, MinimumLength = 3,
                        ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
		public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório."),
         StringLength(7, MinimumLength = 1,
                          ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
		public string Sigla { get; set; }
        
		public ICollection<FuncionarioDto> Funcionarios { get; set; }
    }
}