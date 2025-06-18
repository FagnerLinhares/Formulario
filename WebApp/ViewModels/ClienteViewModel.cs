using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Tamanho máximo {0} e mínimo {1}", MinimumLength = 3)]
        [Required( ErrorMessage = "Campo Obrigatório!")]
        public string? Nome { get; set; }

        [MaxLength(50, ErrorMessage = "Campo máximo de {0}")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string? Sobrenome { get; set; }

        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(14)]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string? Cpf { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50)]
        public string? Email { get; set; }


        public EnderecoViewModel? EnderecoViewModel { get; set; }
    }
}
