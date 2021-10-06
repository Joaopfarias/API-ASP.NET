using ProjetoRH.Models;
using ProjetoRH.Responses;
using System.Collections.Generic;

namespace ProjetoRH.Repositories
{
    public static class ProdutoRepository
    {
        public static ReturnResponse Gravar(Produto produto)
        {
            try
            {
                BaseRepository.Command(produto);
                return new ReturnResponse(200, "Produto Cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar erro:", ex.Message));
            }
        }
        public static ReturnResponse Atualizar(Produto produto)
        {
            try
            {
                BaseRepository.Command(produto, true);
                return new ReturnResponse(200, "Produto atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizar erro:", ex.Message));
            }
        }

        public static List<Produto> Buscar(int CODIGOPRODUTO = 0, string NOMEPRODUTO = "")
        {
            string sql = "select * from PRODUTO";

            if (CODIGOPRODUTO > 0)
            {
                sql += " where CODIGOPRODUTO = @CODIGOPRODUTO";
            }

            if (!string.IsNullOrEmpty(NOMEPRODUTO))
            {
                if (sql.Contains(" where"))
                    sql += " where NOMEPRODUTO like @NOMEPRODUTO";
                else
                    sql += " where NOMEPRODUTO like @NOMEPRODUTO";
            }

            var retorno = BaseRepository.QuerySql<Produto>(sql, new { CODIGOPRODUTO = CODIGOPRODUTO, NOMEPRODUTO = "%" + NOMEPRODUTO + "%" });
            return retorno;
        }
        
        public static ReturnResponse Delete(int CODIGO)
        {
            try
            {
                BaseRepository.Delete<Produto>(CODIGO);
                return new ReturnResponse(200, "Produto deletado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao deletar erro:", ex.Message));
            }
        }
    }
}
