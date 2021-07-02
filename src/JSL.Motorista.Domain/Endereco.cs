using FluentValidation;
using JSL.Core.DomainObjects;

namespace JSL.Motorista.Domain
{
    public class Endereco : ValueObject
    {
        public string Descricao { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }

        public Endereco(string descricao, string logradouro, string numero, string bairro, string municipio, string estado, string cep)
        {
            Descricao = descricao;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Municipio = municipio;
            Estado = estado;
            CEP = cep;
        }

        // EF Rel.
        protected Endereco() { }

        public string EnderecoCompleto()
        {
            return $"{Descricao} {Logradouro}, {Numero} {Bairro} - {Municipio} - {Estado} - {CEP}";
        }

        public override string ToString()
        {
            return EnderecoCompleto();
        }

        public override bool EhValido()
        {
            ValidationResult = new EnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class EnderecoValidation : AbstractValidator<Endereco>
        {
            public EnderecoValidation()
            {
                RuleFor(e => e.Descricao)
                .NotEmpty()
                .WithMessage("A descrição não foi informada");

                RuleFor(e => e.Logradouro)
                .NotEmpty()
                .WithMessage("O Logradouro não foi informado");

                RuleFor(e => e.Numero)
                .NotEmpty()
                .WithMessage("O número não foi informado");

                RuleFor(e => e.Bairro)
                .NotEmpty()
                .WithMessage("O Bairro não foi informado");

                RuleFor(e => e.Municipio)
                .NotEmpty()
                .WithMessage("O município não foi informado");

                RuleFor(e => e.Estado)
                .NotEmpty()
                .WithMessage("O Estado não foi informado");

                RuleFor(e => e.CEP)
                .NotEmpty()
                .WithMessage("O CEP não foi informado");
            }
        }
    }
}
