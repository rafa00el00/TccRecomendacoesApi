using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public interface IUsuarioRecomendacaoService
    {
        Task<IList<string>> GetAsync(string key);
        Task AddMovimentacaoAsync(MovimentacaoVisita movimentacaoVisita);
    }

    public class UsuarioRecomendacaoService : IUsuarioRecomendacaoService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public UsuarioRecomendacaoService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:RECOMENDACAOUSUARIOAPI:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task AddMovimentacaoAsync(MovimentacaoVisita movimentacaoVisita)
        {

            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(movimentacaoVisita),Encoding.Default,"application/json");

            var response = await http.PostAsync(BaseUrl + "/AddMovimentacao", content);

            if (response.IsSuccessStatusCode)
            {

            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<IList<string>> GetAsync(string key)
        {
            var http = new HttpClient();

            var response = await http.GetAsync(BaseUrl + "/Similares/" + key);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IList<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }


        }


    }
}
