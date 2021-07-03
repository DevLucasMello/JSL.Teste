using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSL.Viagem.Data.Mappings
{
    class ViagemMapping : IEntityTypeConfiguration<Domain.Viagem>
    {
        public void Configure(EntityTypeBuilder<Domain.Viagem> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.MotoristaId)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(v => v.DataHoraViajem)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(v => v.LocalEntrega)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(v => v.LocalSaida)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(v => v.Km)
               .IsRequired()
               .HasColumnType("float");

            builder.ToTable("Viagem");
        }
    }
}
