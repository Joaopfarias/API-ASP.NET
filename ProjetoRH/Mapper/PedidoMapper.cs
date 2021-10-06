using ProjetoRH.Models;
using ProjetoRH.Requests;
using ProjetoRH.Responses;
using System.Linq;

namespace ProjetoRH.Mapper
{
    public static class PedidoMapper
    {
        public static Pedido Mapper(PedidoRequest pedidoRequest)
        {
            return new Pedido()
            {
                CODIGOPEDIDO = pedidoRequest.CODIGOPEDIDO,
                DTPEDIDO = pedidoRequest.DTPEDIDO,
                NOMECLIENTE = pedidoRequest.NOMECLIENTE,
                EMAILCLIENTE = pedidoRequest.EMAILCLIENTE,
                ITENS = pedidoRequest.ITENS.Select(p => PedidoItemMapper.Mapper(p)).ToList()
            };
        }
        public static PedidoResponse Mapper(Pedido pedido)
        {
            return new PedidoResponse()
            {
                CODIGOPEDIDO = pedido.CODIGOPEDIDO.ToString(),
                NOMECLIENTE = pedido.NOMECLIENTE,
                EMAILCLIENTE = pedido.EMAILCLIENTE,
                DTPEDIDO = pedido.DTPEDIDO.ToString(),
                ITENS = pedido.ITENS.Select(p => PedidoItemMapper.Mapper(p)).ToList()
            };
        }
    }
}
