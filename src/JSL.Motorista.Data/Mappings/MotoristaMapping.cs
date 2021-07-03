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
                .HasColumnName("UltimoNome")
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
               .HasColumnName("Logradouro")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Numero)
               .HasColumnName("Numero")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Bairro)
               .HasColumnName("Bairro")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Municipio)
               .HasColumnName("Municipio")
               .HasColumnType("varchar(100)");

                e.Property(m => m.Estado)
               .HasColumnName("Estado")
               .HasColumnType("varchar(100)");

                e.Property(m => m.CEP)
               .HasColumnName("CEP")
               .HasColumnType("varchar(100)");
            });

            builder.ToTable("Motorista");
        }
    }
}
