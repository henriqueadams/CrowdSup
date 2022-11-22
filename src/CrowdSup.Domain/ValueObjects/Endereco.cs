namespace CrowdSup.Domain.ValueObjects
{
    public class Endereco
    {
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }

        public Endereco(string estado, string cidade, string bairro, string rua, string numero)
        {
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }
    }
}