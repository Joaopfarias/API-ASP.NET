using Dapper.Contrib.Extensions;

namespace ProjetoRH.Models
{
    [Table("CLIENTE")]
    public class Cliente : BaseModel
    {
        [ExplicitKey]
        public int CODIGOCLIENTE { get; set; }
        public string NOMECLIENTE { get; set; }
        public string EMAILCLIENTE { get; set; }
    }
}
