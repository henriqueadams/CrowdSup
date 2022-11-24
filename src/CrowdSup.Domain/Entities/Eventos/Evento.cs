using CrowdSup.Domain.Entities.Usuarios;
using CrowdSup.Domain.Entities.Voluntarios;
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
        public ICollection<Voluntario> Voluntarios { get; private set; }
        public bool Cancelado { get; private set; }
        public int? QuantidadeParticipantes => Voluntarios?.Count;
        public bool Ativo => (DataEvento > DateTime.Now) && !Cancelado;
        public bool VagasDisponiveis => QuantidadeParticipantes < QuantidadeVoluntariosNecessarios;

        private Evento() { }

        public Evento(
            string titulo,
            string descricao,
            Endereco endereco,
            DateTime dataEvento,
            int quantidadeVoluntariosNecessarios,
            Usuario organizador
        )
        {
            Titulo = titulo;
            Descricao = descricao;
            DataEvento = dataEvento;
            Endereco = endereco;
            QuantidadeVoluntariosNecessarios = quantidadeVoluntariosNecessarios;
            OrganizadorId = organizador.Id;
            Organizador = organizador;
        }

        public void Cancelar()
            => Cancelado = true;
    }
}