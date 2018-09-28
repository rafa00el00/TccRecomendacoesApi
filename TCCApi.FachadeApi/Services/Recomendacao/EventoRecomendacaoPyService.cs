using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public class EventoRecomendacaoPyService : IEventoRecomendacaoPyService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public EventoRecomendacaoPyService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:RECOMENDACAOEVENTOPY:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task<Evento> PostAsync(Evento evento)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(evento),System.Text.Encoding.Default,"application/json");
            var response = await http.PostAsync(BaseUrl + "/Evento", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Evento>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento ");
            }
        }

        public async Task GetRunMakeRecomendacao()
        {
            var http = new HttpClient();
            var response =  await http.GetAsync(BaseUrl + "/Make");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Iniciou servico");
            }
            else
            {
                Console.WriteLine((await response.Content.ReadAsStringAsync()));
            }

        }

        public async Task<IList<string>> GetCodigoEventosSimilaresAsync(string[] tags)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new { evento = tags }), System.Text.Encoding.Default, "application/json");
            var response = await http.PostAsync(BaseUrl + "/SimilaresCodEvento", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IList<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento ");
            }
        }
    }
}
