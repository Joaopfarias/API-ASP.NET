using System.Collections.Generic;

namespace ProjetoRH.Responses
{
    public class PedidoResponse
    {
        public string CODIGOPEDIDO { get; set; }
        public string NOMECLIENTE { get; set; }
        public string EMAILCLIENTE { get; set; }
        public string DTPEDIDO { get; set; }
        public List<PedidoItemResponse> ITENS { get; set; }
    }
}
