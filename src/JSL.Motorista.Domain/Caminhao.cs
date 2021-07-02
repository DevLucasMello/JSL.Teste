using FluentValidation;
using FluentValidation.Results;
using JSL.Core.DomainObjects;
using System;

namespace JSL.Motorista.Domain
{
    public class Caminhao : ValueObject    
    {
        
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public int Eixos { get; private set; }        

        public Caminhao(string marca, string modelo, string placa, int eixos)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Eixos = eixos;
        }

        // EF Rel.
        protected Caminhao() { }        

        public override bool EhValido()
        {
            ValidationResult = new EnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class EnderecoValidation : AbstractValidator<Caminhao>
        {
            public EnderecoValidation()
            {
                RuleFor(c => c.Marca)
                .NotEmpty()
                .WithMessage("A Marca não foi informada");

                RuleFor(c => c.Modelo)
                .NotEmpty()
                .WithMessage("O Modelo não foi informado");

                RuleFor(c => c.Placa)
                .NotEmpty()
                .WithMessage("A Placa não foi informado");

                RuleFor(c => c.Eixos)
                .NotEmpty()
                .WithMessage("A quantidade de Eixos não foi informada");
            }
        }
    }
}
