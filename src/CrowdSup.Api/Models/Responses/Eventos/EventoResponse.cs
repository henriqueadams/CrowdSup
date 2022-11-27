using CrowdSup.Api.Models.Responses.Usuarios;
using CrowdSup.Domain.ValueObjects;

namespace CrowdSup.Api.Models.Responses.Eventos
{
    public class EventoResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataEvento { get; set; }
        public UsuarioResponse Organizador { get; set; }
        public int QuantidadeVoluntariosNecessarios { get; set; }
        public int? QuantidadeParticipantes { get; set; }
        public bool Cancelado { get; set; }
        public bool Expirado { get; set; }
        public bool VagasDisponiveis { get; set; }
        public bool EstaNoEvento { get; set; }

        public EventoResponse(
            int id,
            string titulo,
            string descricao,
            Endereco endereco,
            DateTime dataEvento,
            UsuarioResponse organizador,
            int quantidadeVoluntariosNecessarios,
            int? quantidadeParticipantes,
            bool cancelado,
            bool expirado,
            bool vagasDisponiveis,
            bool estaNoEvento
        )
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Endereco = endereco;
            DataEvento = dataEvento;
            Organizador = organizador;
            QuantidadeVoluntariosNecessarios = quantidadeVoluntariosNecessarios;
            QuantidadeParticipantes = quantidadeParticipantes;
            Cancelado = cancelado;
            Expirado = expirado;
            VagasDisponiveis = vagasDisponiveis;
            EstaNoEvento = estaNoEvento;
        }
    }
}