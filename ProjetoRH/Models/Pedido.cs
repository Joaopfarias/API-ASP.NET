using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace ProjetoRH.Models
{
    [Table("PEDIDO")]
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            ITENS = new List<PedidoItem>();

        }
        [ExplicitKey]
        public int CODIGOPEDIDO { get; set; }
        public string NOMECLIENTE { get; set; }
        public string EMAILCLIENTE { get; set; }
        public DateTime DTPEDIDO { get; set; }
        public List<PedidoItem> ITENS { get; set; }

    }
}
