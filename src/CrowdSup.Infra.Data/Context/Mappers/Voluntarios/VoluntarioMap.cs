using CrowdSup.Domain.Entities.Voluntarios;
using CrowdSup.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrowdSup.Infra.Data.Context.Mappers.Voluntarios
{
    public class VoluntarioMap : IEntityTypeConfiguration<Voluntario>
    {
        public void Configure(EntityTypeBuilder<Voluntario> builder)
        {
            builder.ToTable("VOLUNTARIOS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID").UseHiLo(Sequences.Voluntario).IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnName("USUARIO_ID").IsRequired();
            builder.Property(x => x.EventoId).HasColumnName("EVENTO_ID").IsRequired();

            builder.HasOne(x => x.Usuario)
               .WithMany()
               .HasForeignKey(x => x.UsuarioId).HasConstraintName("FK_VOLUNTARIO_USUARIO");

            builder.HasOne(x => x.Evento)
               .WithMany()
               .HasForeignKey(x => x.EventoId).HasConstraintName("FK_VOLUNTARIO_EVENTO");
        }
    }
}