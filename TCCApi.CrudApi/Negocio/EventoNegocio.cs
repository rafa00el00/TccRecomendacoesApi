using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.CrudApi.Dados;
using TCCApi.CrudApi.Models;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Negocio
{


    public interface IEventoNegocio: IGenericNegocio<Evento,EventoDTO>
    {
        
    }

    public class EventoNegocio : GenericNegocio<Evento,EventoDTO> , IEventoNegocio
    {
        

        public EventoNegocio(IEventoDados eventoDados) : base(eventoDados)
        {
            
        }

        
    }

    

    





}
