namespace PedidoFacil.Application.Requests
{
    public class UpdateProdutoRequest
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
