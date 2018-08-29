using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public interface IUsuarioRecomendacaoService
    {
        Task<IList<string>> GetAsync(string key);
    }

    public class UsuarioRecomendacaoService : IUsuarioRecomendacaoService
    {
        public string BaseUrl { get => "http://localhost:5004"; }

        public async Task<IList<string>> GetAsync(string key)
        {
            var http = new HttpClient();

            var response = await http.GetAsync(BaseUrl + "/Similares/" + key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar Recomendações");
            }


        }
    }

    public interface IEventoRecomendacaoService
    {
        Task<RecomendacaoSimples> GetAsync(int key);
    }
    public class EventoRecomendacaoService : IEventoRecomendacaoService
    {
        public string BaseUrl { get => "http://localhost:5002/api"; }

        public async Task<RecomendacaoSimples> GetAsync(int key)
        {
            var http = new HttpClient();

            var response = await http.GetAsync(BaseUrl + "/Recomendacao/" + key);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<RecomendacaoSimples>( await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar Recomendações");
            }


        }
    }
    }
