using CrowdSup.Domain.Entities.Eventos;
using CrowdSup.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrowdSup.Infra.Data.Context.Mappers.Eventos
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("EVENTOS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID").UseHiLo(Sequences.Evento).IsRequired();
            builder.Property(x => x.Titulo).HasColumnName("TITULO").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(500).IsRequired();;
            builder.Property(x => x.DataEvento).HasColumnName("DATA_EVENTO").IsRequired();
            builder.Property(x => x.OrganizadorId).HasColumnName("ORGANIZADOR_ID").IsRequired();
            builder.Property(x => x.QuantidadeVoluntariosNecessarios).HasColumnName("QTD_VOLUNT_NEC").IsRequired();
            builder.Property(x => x.QuantidadeParticipantes).HasColumnName("QTD_PARTICIPANTES");

            MapEndereco(builder);

            builder.HasOne(x => x.Organizador)
                .WithMany()
                .HasForeignKey(x => x.OrganizadorId).HasConstraintName("FK_EVENTO_ORGANIZADOR");
        }

        private void MapEndereco(EntityTypeBuilder<Evento> builder)
        {
            builder.OwnsOne(x => x.Endereco, (itemBuilder) =>
            {
                itemBuilder.Property(x => x.Cidade).HasColumnName("ESTADO");
                itemBuilder.Property(x => x.Cidade).HasColumnName("CIDADE");
                itemBuilder.Property(x => x.Bairro).HasColumnName("BAIRRO");
                itemBuilder.Property(x => x.Rua).HasColumnName("RUA");
                itemBuilder.Property(x => x.Numero).HasColumnName("NUMERO");
            });
        }
    }
}