using Microsoft.AspNetCore.Mvc;
using ProjetoRH.Mapper;
using ProjetoRH.Repositories;
using ProjetoRH.Requests;
using ProjetoRH.Responses;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PedidoResponse>> Get()
        {
            var pedidos = PedidoRepository.Buscar().Select(p => PedidoMapper.Mapper(p));
            return pedidos.ToList();
        }

        [HttpGet("{CODIGOPEDIDO}")]
        public ActionResult<PedidoResponse> Get(int CODIGOPEDIDO)
        {
            var pedido = PedidoMapper.Mapper(PedidoRepository.Buscar(CODIGOPEDIDO).FirstOrDefault());
            return pedido;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] PedidoRequest request)
        {
            var pedido = PedidoMapper.Mapper(request);
            return PedidoRepository.Gravar(pedido);
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] PedidoRequest request)
        {
            var pedido = PedidoMapper.Mapper(request);
            return PedidoRepository.Atualizar(pedido);
        }

        [HttpDelete]
        public ActionResult<ReturnResponse> Delete(int CODIGOPEDIDO)
        {
            return PedidoRepository.Delete(CODIGOPEDIDO);
        }
    }
}
