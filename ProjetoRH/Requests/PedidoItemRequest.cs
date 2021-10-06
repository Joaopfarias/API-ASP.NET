using ProjetoRH.Responses;

namespace ProjetoRH.Requests
{
    public class PedidoItemRequest
    {
        public int CODIGOPEDIDO { get; set; }
        public string NOMEPRODUTO { get; set; }
        public int QUANTIDADE { get; set; }
        public decimal VALOR { get; set; }
        public PedidoItemRequest ITENS { get; set; }
    }
}
