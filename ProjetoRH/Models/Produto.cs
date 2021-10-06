using Dapper.Contrib.Extensions;

namespace ProjetoRH.Models
{
    [Table("PRODUTO")]
    public class Produto : BaseModel
    {
        [ExplicitKey]
        public int CODIGOPRODUTO { get; set; }
        public string NOMEPRODUTO { get; set; }
        public decimal VALOR { get; set; }
        public int QUANTIDADE { get; set; }
    }
}
