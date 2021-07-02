using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSL.Motorista.Data.Mappings
{
    public class MotoristaMapping : IEntityTypeConfiguration<Domain.Motorista>
    {
        public void Configure(EntityTypeBuilder<Domain.Motorista> builder)
        {
            builder.HasKey(m => m.Id);

            builder.OwnsOne(m => m.Nome, n =>
            {
                n.Property(m => m.PrimeiroNome)
                .HasColumnName("PrimeiroNome")
                .HasColumnType("varchar(50)");

                n.Property(m => m.UltimoNome)
                .HasColumnName("PrimeiroNome")
                .HasColumnType("varchar(50)");
            });

            builder.OwnsOne(m => m.Caminhao, c =>
            {                
                c.Property(m => m.Marca)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                c.Property(m => m.Modelo)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

                c.Property(m => m.Placa)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

                c.Property(m => m.Eixos)
                   .IsRequired()
                   .HasColumnType("int");
            });

            builder.OwnsOne(m => m.Endereco, e =>
            {
                e.Property(m => m.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(100)");

                e.Property(m => m.Logradouro)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Numero)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Bairro)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Municipio)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Estado)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");

                e.Property(m => m.CEP)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");
            });

            builder.ToTable("Motorista");
        }
    }
}
