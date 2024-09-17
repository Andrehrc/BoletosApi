namespace BoletosApi.Models.Dtos
{
    public class BancoRequest
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public decimal Juros { get; set; }
    }
}
