using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Dados
{




    public interface IEventoDados : IGenericDados<EventoDTO>
    {
        
    }

    public class EventoDados : GenericDados<EventoDTO> , IEventoDados
    {
        
        public EventoDados(DbContext context):base(context)
        {
        }

    }

   
}
