using CrowdSup.Domain.ValueObjects;

namespace CrowdSup.Api.Models.Requests.Eventos
{
    public class CriarEventoRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataEvento { get; set; }
        public int QuantidadeVoluntariosNecessarios { get; set; }
    }
}