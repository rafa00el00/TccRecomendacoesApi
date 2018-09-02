using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public interface IEventoRecomendacaoPyService
    {
        string BaseUrl { get; }

        Task<Evento> PostAsync(Evento evento);
    }
}