using Dapper;
using MySql.Data.MySqlClient;
using ProjetoRH.Models;
using ProjetoRH.Responses;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoRH.Repositories
{
    public static class PedidoRepository
    {
        public static ReturnResponse Gravar(Pedido pedido)
        {
            try
            {
                BaseRepository.Command(pedido);
                return new ReturnResponse(200, "Pedido Cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar erro:", ex.Message));
            }
        }
        public static ReturnResponse Atualizar(Pedido pedido)
        {
            try
            {
                BaseRepository.Command(pedido, true);
                return new ReturnResponse(200, "Pedido Atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizar erro:", ex.Message));
            }
        }
        public static ReturnResponse Delete(int CODIGOPEDIDO)
        {
            try
            {
                BaseRepository.Delete<Pedido>(CODIGOPEDIDO);
                return new ReturnResponse(200, "Pedido deletado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao deletar erro:", ex.Message));
            }
        }
        public static List<Pedido> Buscar(int CODIGOPEDIDO = 0, int CODIGOCLIENTE = 0)
        {
            string sql = "select * from PEDIDO";

            if (CODIGOPEDIDO > 0)
            {
                sql += " where CODIGOPEDIDO = @CODIGOPEDIDO";
            }

            if (CODIGOCLIENTE > 0)
            {
                if (sql.Contains("where"))
                    sql += " and CODIGOCLIENTE = @CODIGOCLIENTE";
                else
                    sql += " where CODIGOCLIENTE = @CODIGOCLIENTE";
            }

            var retorno = BaseRepository.QuerySql<Pedido>(sql, new { CODIGOPEDIDO = CODIGOPEDIDO, CODIGOCLIENTE = CODIGOCLIENTE });
            return retorno;
        }
            /*
            string sql = @" select * from PEDIDOD";

            if (CODIGOPEDIDO > 0)
            {
                sql += " where CODIGOPEDIDO = @CODIGOPEDIDO";
            }

            if (CODIGOCLIENTE > 0)
            {
                if (sql.Contains("where"))
                    sql += " and CODIGOCLIENTE = @CODIGOCLIENTE";
                else
                    sql += " where CODIGOCLIENTE = @CODIGOCLIENTE";
            }

            List<Pedido> orderDetail;
            using (var connection = new MySqlConnection(BaseRepository.ConnectionString))
            {
                orderDetail = connection.Query<Pedido, Cliente, Pedido>(sql, map: mapPropriedades, splitOn: "CODIGOCLIENTE", param: new { CODIGOPEDIDO = CODIGOPEDIDO, CODIGOCLIENTE = CODIGOCLIENTE }).ToList();
            }

            const string sqlItem = @"select*from PEDIDO where CODIGOPEDIDO = @CODIGOPEDIDO";

            foreach (var item in orderDetail)
            {
                using (var connection = new MySqlConnection(BaseRepository.ConnectionString))
                {
                    item.ITENS.AddRange(connection.Query<PedidoItem>(sqlItem, param: new { CODIGOPEDIDO = item.CODIGOPEDIDO }).ToList());
                }
            }

            return orderDetail;
        }
        private static Pedido mapPropriedades(Pedido pedido, Cliente cliente)
        {
            pedido.Cliente = cliente;

            return pedido;
        }*/
    }
}
