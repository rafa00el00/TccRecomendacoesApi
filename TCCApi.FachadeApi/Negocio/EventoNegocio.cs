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
        Task<IList<ItemEvento>> GetAllAsync();
        Task<IList<ItemEvento>> GetEventosRecomendacoesAsync();
        Task<IList<ItemEvento>> GetEventosEmAltaAsync();
        Task<IList<ItemEvento>> GetEventosUltimosVisitadosAsync();
        Task<IList<ItemEvento>> GetRecomendacoesPorEventoAsync(string keyEvento);

        Task<IList<Evento>> GetPorEmpresaAsync();
        Task<Evento> PostAsync(Evento evento);
        Task<Evento> PutAsync(Evento evento);
        Task<IList<ItemEvento>> GetAllPageAsync(int pageNum, int qtd);

        Task<IList<string>> GetAllTagsAsync();
        Task<IList<string>> TextToTags(string textos);
        Task<IList<string>> RecomendacaoPublicoAlvoAsync(IList<string> tags);
        
        
    }

    public class EventoNegocio : IEventoNegocio
    {
        private readonly IEventoCrudService _eventoCrudService;
        private readonly IEventoRecomendacaoService _eventoRecomendacaoService;
        private readonly IUsuarioRecomendacaoService _usuarioRecomendacaoService;
        private readonly IVisitaService _visitaService;
        private readonly IEventoRecomendacaoPyService _eventoRecomendacaoPy;
        private readonly ITextoRecomendacaoService _textoRecomendacaoService;
        private readonly SharedInfo sharedInfo;

        public EventoNegocio(IEventoCrudService eventoCrudService,
            IEventoRecomendacaoService eventoRecomendacaoService,
            IUsuarioRecomendacaoService usuarioRecomendacaoService,
            IVisitaService visitaService,
            IEventoRecomendacaoPyService eventoRecomendacaoPy,
            ITextoRecomendacaoService textoRecomendacaoService,
            SharedInfo sharedInfo)
        {
            this._eventoCrudService = eventoCrudService;
            this._eventoRecomendacaoService = eventoRecomendacaoService;
            this._usuarioRecomendacaoService = usuarioRecomendacaoService;
            this._visitaService = visitaService;
            this._eventoRecomendacaoPy = eventoRecomendacaoPy;
            this._textoRecomendacaoService = textoRecomendacaoService;
            this.sharedInfo = sharedInfo;
        }

       
        

        public async Task<IList<ItemEvento>> GetAllAsync()
        {
            var eventos = await _eventoCrudService.GetAllAsync();

            return Mapper.Map<IList<ItemEvento>>(eventos);

        }
        public async Task<IList<ItemEvento>> GetAllPageAsync(int page,int qtd)
        {

            var eventos = await _eventoCrudService.GetAllPageAsync(page, qtd);


            return Mapper.Map<IList<ItemEvento>>(eventos);

        }

        public async Task<IList<string>> GetAllTagsAsync()
        {
            var tags = await _eventoCrudService.GetAllTagsAsync();
            return tags;
        }

        public async Task<Evento> GetAsync(int key)
        {
            var retorno = await _eventoCrudService.GetAsync((key));
            try
            {
                await _usuarioRecomendacaoService.AddMovimentacaoAsync(new MovimentacaoVisita
                {
                    usuario = sharedInfo.CodUsuario,
                    evento = key.ToString(),
                    status = "1"
                });
            }
            catch (Exception ex)
            {
            }
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

            var listaEventosCodigo = await _usuarioRecomendacaoService.GetAsync(sharedInfo.CodUsuario);
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
           
                var visitas = await _visitaService.GetUltimasVisitasAsync(sharedInfo.CodUsuario);

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

        public async Task<IList<Evento>> GetPorEmpresaAsync()
        {
            return await _eventoCrudService.GetPorEmpresaAsync(sharedInfo.CodEmpresa);
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

        public async Task<Evento> PostAsync(Evento evento)
        {
            evento.IdEmpresa = sharedInfo.CodEmpresa;
            evento.EmpresaNome = sharedInfo.empresa.Name;
            var eventoRet = await _eventoCrudService.PostAsync(evento);
            await _eventoRecomendacaoPy.PostAsync(eventoRet);
            return eventoRet;
        }

        public async Task<Evento> PutAsync(Evento evento)
        {
            return await _eventoCrudService.PutAsync(evento);
        }

        public async Task<IList<string>> RecomendacaoPublicoAlvoAsync(IList<string> tags)
        {
            return await Task.Run(() => {
                return new List<string>
            {
                "teste","abacaxi","laranja"
            };
            });
        }

        public async Task<IList<string>> TextToTags(string textos)
        {
            var tags = await _textoRecomendacaoService.PostTextoToTagsAsync(textos);

            return tags;
        }


    }


}
