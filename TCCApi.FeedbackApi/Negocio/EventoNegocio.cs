using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TCCApi.FeedbackApi.Dados;
using TCCApi.FeedbackApi.Models;
using TCCApi.FeedbackApi.Models.DTO;

namespace TCCApi.FeedbackApi.Negocio
{


    public interface IFeedbackNegocio : IGenericNegocio<Feedback, FeedbackDTO>
    {
        IList<Feedback> GetFromEventos(string codEvento);
    }

    public class FeedbackNegocio : GenericNegocio<Feedback, FeedbackDTO> , IFeedbackNegocio
    {
        private readonly IFeedbackDados _eventoDados;

        public FeedbackNegocio(IFeedbackDados eventoDados) : base(eventoDados)
        {
            this._eventoDados = eventoDados;
        }

        public IList<Feedback> GetFromEventos(string codEvento)
        {
            var feedbackTo =  _eventoDados.GetAll().Where(e => e.CodEvento.Equals(codEvento)).ToList();
            return Mapper.Map<IList<Feedback>>(feedbackTo);
         }

    }

    

    





}
