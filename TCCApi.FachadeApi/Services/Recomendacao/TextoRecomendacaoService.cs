using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public interface ITextoRecomendacaoService
    {
        Task<RecomendacaoSimples> GetAsync(int key);
    }

    public class TextoRecomendacaoService : ITextoRecomendacaoService
    {
        public string BaseUrl { get => "http://localhost:5003/api"; }

        public async Task<RecomendacaoSimples> GetAsync(int key)
        {
            var http = new HttpClient();

            var response = await http.GetAsync(BaseUrl + "/Recomendacao/" + key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<RecomendacaoSimples>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar Recomendações");
            }


        }
    }
    }
