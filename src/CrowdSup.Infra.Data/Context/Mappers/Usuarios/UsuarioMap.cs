using CrowdSup.Domain.Entities.Usuarios;
using CrowdSup.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrowdSup.Infra.Data.Context.Mappers.Usuarios
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID").UseHiLo(Sequences.Usuario).IsRequired();
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Senha).HasColumnName("SENHA").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnName("DATA_NASCIMENTO").IsRequired();
            builder.Property(x => x.Cidade).HasColumnName("CIDADE").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Estado).HasColumnName("ESTADO").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("TELEFONE").HasMaxLength(15).IsRequired();
            builder.Property(x => x.Sexo).HasColumnName("SEXO").IsRequired();
        }
    }
}