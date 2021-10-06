using System;
using System.Collections.Generic;

namespace ProjetoRH.Requests
{
    public class PedidoRequest
    {
        public int CODIGOPEDIDO { get; set; }
        public string NOMECLIENTE { get; set; }
        public string EMAILCLIENTE { get; set; }
        public DateTime DTPEDIDO { get; set; }
        public List<PedidoItemRequest> ITENS { get; set; }
    }
}
