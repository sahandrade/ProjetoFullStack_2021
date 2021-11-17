using System.ComponentModel.DataAnnotations;
using Enterprise.Domain;

namespace Enterprise.Application.Dtos
{
    public class FuncionarioDto
    {    
        public int FuncionarioId { get; set;}
         [Required(ErrorMessage = "O campo {0} é obrigtório."),
         //MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres."),
         //MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres.")
         StringLength(50, MinimumLength = 3,
                          ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
		public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
		public string Rg { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                           ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
		public string FotoUrl {get; set; }

		public int DeptoId { get; set;}
        
    }
}