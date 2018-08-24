using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Services.Recomendacao;
using TCCApi.FachadeApi.ViewModel;

namespace TCCApi.FachadeApi.Negocio
{

    public interface IEventoNegocio
    {
        Task<EventoDetalhesViewModel> GetAsync(int key);
        Task<EventosListaViewModel> GetAllAsync();
    }

    public class EventoNegocio : IEventoNegocio
    {
        private readonly IEventoCrudService _eventoCrudService;
        private readonly IEventoRecomendacaoService _eventoRecomendacaoService;

        public EventoNegocio(IEventoCrudService eventoCrudService, IEventoRecomendacaoService eventoRecomendacaoService)
        {
            this._eventoCrudService = eventoCrudService;
            this._eventoRecomendacaoService = eventoRecomendacaoService;
        }


        public async Task<EventosListaViewModel> GetAllAsync()
        {
            return new EventosListaViewModel
            {
                Eventos = await _eventoCrudService.GetAllAsync()
            };
                
        }

        public async Task<EventoDetalhesViewModel> GetAsync(int key)
        {
            var recomendacao = await _eventoRecomendacaoService.GetAsync(key);
            var similares = new List<Evento>();

            foreach (var sim in recomendacao.Similares)
            {
                similares.Add(await _eventoCrudService.GetAsync(int.Parse(sim)));
            }
            return new EventoDetalhesViewModel
            {
                Evento = await _eventoCrudService.GetAsync(int.Parse(recomendacao.Codigo)),
                Similares = similares

            };
        }
    }


}
