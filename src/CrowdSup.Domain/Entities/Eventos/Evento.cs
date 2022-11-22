using CrowdSup.Domain.Entities.Usuarios;
using CrowdSup.Domain.ValueObjects;

namespace CrowdSup.Domain.Entities.Eventos
{
    public class Evento
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Endereco Endereco { get; private set; }
        public DateTime DataEvento { get; private set; }
        public int OrganizadorId { get; private set; }
        public Usuario Organizador { get; private set; }
        public int QuantidadeVoluntariosNecessarios { get; private set; }
        public int QuantidadeParticipantes { get; private set; }

        private Evento() { }

        public Evento(
            int id,
            string titulo,
            string descricao,
            DateTime dataEvento,
            Endereco endereco,
            int quantidadeVoluntariosNecessarios,
            int quantidadeParticipantes,
            Usuario organizador
        )
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataEvento = dataEvento;
            Endereco = endereco;
            QuantidadeVoluntariosNecessarios = quantidadeVoluntariosNecessarios;
            QuantidadeParticipantes = quantidadeParticipantes;
            OrganizadorId = organizador.Id;
            Organizador = organizador;
        }
    }
}