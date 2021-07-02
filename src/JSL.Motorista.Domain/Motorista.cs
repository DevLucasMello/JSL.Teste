using JSL.Core.DomainObjects;

namespace JSL.Motorista.Domain
{
    public class Motorista : Entity, IAggregateRoot
    {
        public Nome Nome { get; private set; }
        public Caminhao Caminhao { get; private set; }
        public Endereco Endereco { get; private set; }

        public Motorista(Nome nome, Caminhao caminhao, Endereco endereco)
        {
            Nome = nome;
            Caminhao = caminhao;
            Endereco = endereco;            
        }

        // EF Rel.
        protected Motorista() { }        
    }
}
