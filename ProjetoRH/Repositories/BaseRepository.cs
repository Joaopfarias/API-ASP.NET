using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using ProjetoRH.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoRH.Repositories
{
    public class BaseRepository
    {
        public const string ConnectionString = "Server=localhost;Database=projetorh2;Uid=root;Pwd=Joao2106.;";
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> ordem;
            using (var connection = new MySqlConnection(ConnectionString))
            {
                ordem = connection.Query<T>(sql, parameter).ToList();

            }

            return ordem;
        }
        public static void Command<T>(T objeto, bool editar = false, object parameter = null) where T : BaseModel
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                if (editar)
                    connection.Update(objeto);
                else
                    connection.Insert(objeto);
            }
        }
        public static void Delete<T>(int CODIGO) where T : BaseModel
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var tabela = typeof(T).Name;
                
                string query;

                if (tabela.Equals("Cliente"))
                    query = $"select * from {tabela} where CODIGOCLIENTE = @CODIGO";
                else if(tabela.Equals("Produto"))
                    query = $"select * from {tabela} where CODIGOPRODUTO = @CODIGO";
                else
                    query = $"select * from {tabela} where CODIGOPEDIDO = @CODIGO";
                var objeto = connection.Query<T>(query, new { CODIGO });
                connection.Delete(objeto);
            }
        }
    }
}
