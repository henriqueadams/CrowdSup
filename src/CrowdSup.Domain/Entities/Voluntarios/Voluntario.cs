using CrowdSup.Domain.Entities.Eventos;
using CrowdSup.Domain.Entities.Usuarios;

namespace CrowdSup.Domain.Entities.Voluntarios
{
    public class Voluntario
    {
        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public int EventoId { get; private set; }
        public Evento Evento { get; private set; }

        private Voluntario() { }

        public Voluntario(int id, Usuario usuario, Evento evento)
        {
            Id = id;
            UsuarioId = usuario.Id;
            Usuario = usuario;
            EventoId = evento.Id;
            Evento = evento;
        }
    }
}