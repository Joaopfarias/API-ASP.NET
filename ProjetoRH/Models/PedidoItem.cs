using Dapper.Contrib.Extensions;

namespace ProjetoRH.Models
{
    [Table("ITENS")]
    public class PedidoItem : BaseModel
    {
        [ExplicitKey]
        public int CODIGOPEDIDO { get; set; }
        public string NOMEPRODUTO { get; set; }
        public int QUANTIDADE { get; set; }
        public decimal VALOR { get; set; }
        //public PedidoItem ITENS { get; set; }
    }
}
