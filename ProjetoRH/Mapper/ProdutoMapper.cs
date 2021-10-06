using ProjetoRH.Models;
using ProjetoRH.Requests;
using ProjetoRH.Responses;

namespace ProjetoRH.Mapper
{
    public static class ProdutoMapper
    {
        public static Produto Mapper(ProdutoRequest produtoRequest)
        {
            return new Produto()
            {
                CODIGOPRODUTO = produtoRequest.CODIGOPRODUTO,
                NOMEPRODUTO = produtoRequest.NOMEPRODUTO,
                VALOR = produtoRequest.VALOR,
                QUANTIDADE = produtoRequest.QUANTIDADE
            };
        }
        public static ProdutoResponse Mapper(Produto produto)
        {
            return new ProdutoResponse()
            {
                CODIGOPRODUTO = produto.CODIGOPRODUTO.ToString(),
                NOMEPRODUTO = produto.NOMEPRODUTO,
                VALOR = produto.VALOR.ToString()
            };
        }
    }
}
