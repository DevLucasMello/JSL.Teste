using System;
using System.ComponentModel.DataAnnotations;

namespace JSL.Viagem.Application.ViewModels
{
    public class ViagemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid MotoristaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataHoraViajem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string LocalEntrega { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string LocalSaida { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Km { get; set; }
    }
}
