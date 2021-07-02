using FluentValidation;
using JSL.Core.DomainObjects;
using System;

namespace JSL.Viagem.Domain
{
    public class Viagem : Entity, IAggregateRoot
    {
        public Guid MotoristaId { get; private set; }
        public DateTime DataHoraViajem { get; private set; }
        public string LocalEntrega { get; private set; }
        public string LocalSaida { get; private set; }
        public double Km { get; private set; }       

        public Viagem(Guid motoristaId, DateTime dataHoraViajem, string localEntrega, string localSaida, double km)
        {
            MotoristaId = motoristaId;
            DataHoraViajem = dataHoraViajem;
            LocalEntrega = localEntrega;
            LocalSaida = localSaida;
            Km = km;
        }

        // EF Rel.
        protected Viagem() { }        

        public override bool EhValido()
        {
            ValidationResult = new EnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class EnderecoValidation : AbstractValidator<Viagem>
        {
            public EnderecoValidation()
            {
                RuleFor(v => v.MotoristaId)
                .NotEmpty()
                .WithMessage("O Campo motoristaId não pode estar vazio");

                RuleFor(v => v.DataHoraViajem)
                .NotEmpty()
                .WithMessage("A Data e Hora da viagem não foi informada");

                RuleFor(v => v.LocalEntrega)
                .NotEmpty()
                .WithMessage("O Local de Entrega não foi informado");

                RuleFor(v => v.LocalSaida)
                .NotEmpty()
                .WithMessage("O Local de Saída não foi informado");

                RuleFor(v => v.Km)
                .GreaterThan(0)
                .WithMessage("O valor do item precisa ser maior que 0");
            }
        }
    }
}
