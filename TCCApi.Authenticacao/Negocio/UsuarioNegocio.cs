using TCCApi.Authenticacao.Dados;
using TCCApi.Authenticacao.Models;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Negocio
{


    public interface IUsuarioNegocio: IGenericNegocio<Usuario, UsuarioDTO>
    {
        
    }

    public class UsuarioNegocio : GenericNegocio<Usuario,UsuarioDTO> , IUsuarioNegocio
    {
        

        public UsuarioNegocio(IUsuarioDados eventoDados) : base(eventoDados)
        {
            
        }

        
    }

    

    





}
