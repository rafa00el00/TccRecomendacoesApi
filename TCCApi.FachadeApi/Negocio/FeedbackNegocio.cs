using System.Collections.Generic;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Services;
using TCCApi.FachadeApi.Utils;

namespace TCCApi.FachadeApi.Negocio
{

    public interface IFeedbackNegocio
    {

        Task<Feedback> GetAsync(int key);
        Task<IList<Feedback>> GetListaFeedbacksAsync(string codEvento);
        Task<Feedback> PostFeedbackAsync(Feedback compra);
    }
    public class FeedbackNegocio : IFeedbackNegocio
    {
        private readonly SharedInfo _sharedInfo;
        private readonly IFeedbackService _feedbackService;

        public FeedbackNegocio(
                SharedInfo sharedInfo,
                IFeedbackService feedbackService
            )
        {
            this._sharedInfo = sharedInfo;
            this._feedbackService = feedbackService;
        }

        public async Task<Feedback> GetAsync(int key)
        {
            return await _feedbackService.GetAsync(key);
        }

        public Task<IList<Feedback>> GetListaFeedbacksAsync(string codEvento)
        {
            return _feedbackService.GetListaFeedBacks(codEvento);
        }

        public async Task<Feedback> PostFeedbackAsync(Feedback feedback)
        {
            feedback.GuidUsuario = _sharedInfo.CodUsuario;
            feedback.NomeUsuario = _sharedInfo.usuario.Name;

            await _feedbackService.PostFeedback(feedback);
            return feedback;
        }
    }
}
