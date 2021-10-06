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
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoResponse>> Get()
        {
            var produtos = ProdutoRepository.Buscar().Select(p => ProdutoMapper.Mapper(p));
            return produtos.ToList();
        }

        [HttpGet("{CODIGOPRODUTO}")]
        public ActionResult<ProdutoResponse> Get(int CODIGOPRODUTO)
        {
            var produto = ProdutoMapper.Mapper(ProdutoRepository.Buscar(CODIGOPRODUTO).FirstOrDefault());
            return produto;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest request)
        {
            var produto = ProdutoMapper.Mapper(request);
            return ProdutoRepository.Gravar(produto);
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest request)
        {
            var produto = ProdutoMapper.Mapper(request);
            return ProdutoRepository.Atualizar(produto);
        }

        [HttpDelete("{CODIGO}")]
        public ActionResult<ReturnResponse> Delete(int CODIGO)
        {
            return ProdutoRepository.Delete(CODIGO);
        }
    }
}
