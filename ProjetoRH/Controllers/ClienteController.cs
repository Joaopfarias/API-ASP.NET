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
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteResponse>> Get()
        {
            var cliente = ClienteRepository.Buscar().Select(p => ClienteMapper.Mapper(p));
            return cliente.ToList();
        }

        [HttpGet("{CODIGOCLIENTE}")]
        public ActionResult<ClienteResponse> Get(int CODIGOCLIENTE)
        {
            var cliente = ClienteMapper.Mapper(ClienteRepository.Buscar(CODIGOCLIENTE).FirstOrDefault());
            return cliente;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ClienteRequest request)
        {
            var cliente = ClienteMapper.Mapper(request);
            return ClienteRepository.Gravar(cliente);
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] ClienteRequest request)
        {
            var Cliente = ClienteMapper.Mapper(request);
            return ClienteRepository.Atualizar(Cliente);
        }

        [HttpDelete("{CODIGOCLIENTE}")]
        public ActionResult<ReturnResponse> Delete(int CODIGOCLIENTE)
        {
            return ClienteRepository.Delete(CODIGOCLIENTE);
        }
    }
}
