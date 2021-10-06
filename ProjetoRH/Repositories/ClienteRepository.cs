using ProjetoRH.Models;
using ProjetoRH.Responses;
using System.Collections.Generic;

namespace ProjetoRH.Repositories
{
    public static class ClienteRepository
    {
        public static ReturnResponse Gravar(Cliente cliente)
        {
            try
            {
                BaseRepository.Command(cliente);
                return new ReturnResponse(200, "Cliente Cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar erro:", ex.Message));
            }
        }
        public static ReturnResponse Atualizar(Cliente cliente)
        {
            try
            {
                BaseRepository.Command(cliente, true);
                return new ReturnResponse(200, "Cliente atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizar erro:", ex.Message));
            }
        }
        public static ReturnResponse Delete(int CODIGOCLIENTE)
        {
            try
            {
                BaseRepository.Delete<Cliente>(CODIGOCLIENTE);
                return new ReturnResponse(200, "Cliente deletado com sucesso!");

            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao deletar erro:", ex.Message));
            }
        }
        public static List<Cliente> Buscar(int CODIGOCLIENTE = 0, string NOMECLIENTE = "")
        {
            string sql = "select * from Cliente";

            if (CODIGOCLIENTE > 0)
            {
                sql += " where CODIGOCLIENTE = @CODIGOCLIENTE";
            }

            if (!string.IsNullOrEmpty(NOMECLIENTE))
            {
                if (sql.Contains("where"))
                    sql += " and NOMECLIENTE like @NOMECLIENTE";
                else
                    sql += " where NOMECLIENTE like @NOMECLIENTE";
            }

            var retorno = BaseRepository.QuerySql<Cliente>(sql, new {CODIGOCLIENTE = CODIGOCLIENTE, NOMECLIENTE = "%" + NOMECLIENTE + "%" });
            return retorno;
        }
    }
}
