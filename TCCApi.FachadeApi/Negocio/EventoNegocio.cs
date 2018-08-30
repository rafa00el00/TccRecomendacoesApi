using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Services.Recomendacao;
using TCCApi.FachadeApi.Utils;
using TCCApi.FachadeApi.ViewModel;

namespace TCCApi.FachadeApi.Negocio
{
    public interface IEventoNegocio
    {
        Task<Evento> GetAsync(int key);
        Task<EventosListaViewModel> GetAllAsync();
        Task<IList<ItemEvento>> GetEventosRecomendacoesAsync();
        Task<IList<ItemEvento>> GetEventosEmAltaAsync();
        Task<IList<ItemEvento>> GetEventosUltimosVisitadosAsync();
        Task<IList<ItemEvento>> GetRecomendacoesPorEventoAsync(string keyEvento);
    }

    public class EventoNegocio : IEventoNegocio
    {
        private readonly IEventoCrudService _eventoCrudService;
        private readonly IEventoRecomendacaoService _eventoRecomendacaoService;
        private readonly IUsuarioRecomendacaoService _usuarioRecomendacaoService;
        private readonly IVisitaService _visitaService;

        public EventoNegocio(IEventoCrudService eventoCrudService,
            IEventoRecomendacaoService eventoRecomendacaoService,
            IUsuarioRecomendacaoService usuarioRecomendacaoService,
            IVisitaService visitaService)
        {
            this._eventoCrudService = eventoCrudService;
            this._eventoRecomendacaoService = eventoRecomendacaoService;
            this._usuarioRecomendacaoService = usuarioRecomendacaoService;
            this._visitaService = visitaService;
        }


        public async Task<EventosListaViewModel> GetAllAsync()
        {
            return new EventosListaViewModel
            {
                Eventos = await _eventoCrudService.GetAllAsync()
            };

        }

        public async Task<Evento> GetAsync(int key)
        {
            var retorno = await _eventoCrudService.GetAsync((key));
            await _usuarioRecomendacaoService.AddMovimentacaoAsync(new MovimentacaoVisita
            {
                usuario = SharedInfo.CodUsuario,
                evento = key.ToString(),
                status = "1"
            });
            return retorno;
               
        }

        public async Task<IList<ItemEvento>> GetEventosEmAltaAsync()
        {
            var visitas = await _visitaService.GetTopMostAsync();

            var listaEventos = new List<ItemEvento>();
            foreach (var visita in visitas)
            {
                var evento = await _eventoCrudService.GetAsync(visita);
                if (evento == null)
                    continue;
                listaEventos.Add(Mapper.Map<ItemEvento>(evento));
            }

            return listaEventos;
        }

        public async Task<IList<ItemEvento>> GetEventosRecomendacoesAsync()
        {

            var listaEventosCodigo = await _usuarioRecomendacaoService.GetAsync(SharedInfo.CodUsuario);
            var listaEventos = new List<ItemEvento>();
            foreach (var cod in listaEventosCodigo)
            {
                var evento = await _eventoCrudService.GetAsync(int.Parse(cod));
                if (evento == null)
                    continue;
                listaEventos.Add(Mapper.Map<ItemEvento>(evento));
            }

            return listaEventos;

        }

        public async Task<IList<ItemEvento>> GetEventosUltimosVisitadosAsync()
        {
           
                var visitas = await _visitaService.GetUltimasVisitasAsync(SharedInfo.CodUsuario);

            var listaEventos = new List<ItemEvento>();
            foreach (var visita in visitas)
            {
                var evento = await _eventoCrudService.GetAsync(visita.IdEvento);
                if (evento == null)
                    continue;
                listaEventos.Add(Mapper.Map<ItemEvento>(evento));
            }

            return listaEventos;
        }

        public async Task<IList<ItemEvento>> GetRecomendacoesPorEventoAsync(string keyEvento)
        {
            var recomendacao = await _eventoRecomendacaoService.GetAsync(int.Parse(keyEvento));
            var similares = new List<ItemEvento>();

            foreach (var sim in recomendacao.Similares)
            {
                try
                {

                    var ev = await _eventoCrudService.GetAsync(int.Parse(sim));
                    if (ev != null)
                        similares.Add(Mapper.Map<ItemEvento>(ev));
                }
                catch (Exception)
                {
                    
                }
                
            }

            return similares;
        }


    }


}
