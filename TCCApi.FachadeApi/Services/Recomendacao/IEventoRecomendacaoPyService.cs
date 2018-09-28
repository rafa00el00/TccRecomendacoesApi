using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public interface IEventoRecomendacaoPyService
    {
        string BaseUrl { get; }

        Task<Evento> PostAsync(Evento evento);
        Task GetRunMakeRecomendacao();
        Task<IList<string>> GetCodigoEventosSimilaresAsync(string[] tags);
    }
}