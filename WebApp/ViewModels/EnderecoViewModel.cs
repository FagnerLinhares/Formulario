using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Tamanho máximo 30 e mínimo 3", MinimumLength =3)]
        [Display(Name = "Rua")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string? Rua { get; set; }

        [MaxLength(30, ErrorMessage = "Campo máximo de {0}")]
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string? Bairro { get; set; }

        [MaxLength(10)]
        [Display(Name = "CEP" )]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string? Cep { get; set; }

        [StringLength(5, ErrorMessage = "Número máximo de 5 caracteres")]
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int Numero {  get; set; }
    }
}
