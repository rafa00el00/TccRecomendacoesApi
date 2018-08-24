using TCCApi.CrudApi.Dados;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Negocio
{

    public interface IClienteNegocio : IGenericNegocio<Cliente, ClienteDTO>
    {

    }
    public class ClienteNegocio : GenericNegocio<Cliente, ClienteDTO>, IClienteNegocio
    {


        public ClienteNegocio(IClienteDados clienteDados) : base(clienteDados)
        {

        }


    }





}
