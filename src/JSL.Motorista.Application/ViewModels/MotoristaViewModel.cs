using System;
using System.ComponentModel.DataAnnotations;

namespace JSL.Motorista.Application.ViewModels
{
    public class MotoristaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UltimoNome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Eixos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CEP { get; set; }
    }
}
