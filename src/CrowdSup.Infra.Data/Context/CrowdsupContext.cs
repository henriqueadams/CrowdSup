using CrowdSup.Domain.Entities.Eventos;
using CrowdSup.Domain.Entities.Usuarios;
using CrowdSup.Domain.Entities.Voluntarios;
using CrowdSup.Infra.Data.Constants;
using CrowdSup.Infra.Data.Context.Extensions;
using CrowdSup.Infra.Data.Context.Mappers.Eventos;
using CrowdSup.Infra.Data.Context.Mappers.Usuarios;
using CrowdSup.Infra.Data.Context.Mappers.Voluntarios;
using Microsoft.EntityFrameworkCore;

namespace CrowdSup.Infra.Data.Context
{
    public class CrowdsupContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }

        public CrowdsupContext(DbContextOptions<CrowdsupContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VoluntarioMap());

            modelBuilder.RegisterSequence(Sequences.Evento);
        }
    }
}