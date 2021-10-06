using ProjetoRH.Models;
using ProjetoRH.Requests;
using ProjetoRH.Responses;

namespace ProjetoRH.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente Mapper(ClienteRequest clienteRequest)
        {
            return new Cliente()
            {
                CODIGOCLIENTE = clienteRequest.CODIGOCLIENTE,
                NOMECLIENTE = clienteRequest.NOMECLIENTE,
                EMAILCLIENTE = clienteRequest.EMAILCLIENTE
            };
        }
        public static ClienteResponse Mapper(Cliente cliente)
        {
            return new ClienteResponse()
            {
                CODIGOCLIENTE = cliente.CODIGOCLIENTE.ToString(),
                NOMECLIENTE = cliente.NOMECLIENTE,
                EMAILCLIENTE = cliente.EMAILCLIENTE
            };
        }
    }
}
