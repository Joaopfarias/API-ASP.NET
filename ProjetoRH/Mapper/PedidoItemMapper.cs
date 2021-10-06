using ProjetoRH.Models;
using ProjetoRH.Requests;
using ProjetoRH.Responses;
using System.Collections.Generic;

namespace ProjetoRH.Mapper
{
    public class PedidoItemMapper
    {
        public static PedidoItem Mapper(PedidoItemRequest pedidoItem)
        {
            return new PedidoItem
            {
                CODIGOPEDIDO = pedidoItem.CODIGOPEDIDO,
                //ITENS = PedidoItemMapper.Mapper(pedidoItem.ITENS),
                NOMEPRODUTO = pedidoItem.NOMEPRODUTO,
                QUANTIDADE = pedidoItem.QUANTIDADE,
                VALOR = pedidoItem.VALOR
            };
        }

        public static PedidoItemResponse Mapper(PedidoItem pedidoItem)
        {
            return new PedidoItemResponse()
            {
                CODIGOPEDIDO = pedidoItem.CODIGOPEDIDO.ToString(),
                //ITENS = PedidoItemMapper.Mapper(pedidoItem.ITENS),
                NOMEPRODUTO = pedidoItem.NOMEPRODUTO,
                QUANTIDADE = pedidoItem.QUANTIDADE.ToString(),
                VALOR = pedidoItem.VALOR.ToString()
            };
        }
    }
}
