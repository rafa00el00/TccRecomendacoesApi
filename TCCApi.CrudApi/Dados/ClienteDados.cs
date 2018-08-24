using Microsoft.EntityFrameworkCore;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Dados
{
    public interface IClienteDados : IGenericDados<ClienteDTO>
    {

    }

    public class ClienteDados : GenericDados<ClienteDTO>, IClienteDados
    {

        public ClienteDados(DbContext context) : base(context)
        {
        }

    }



}
