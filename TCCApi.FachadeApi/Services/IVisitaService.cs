using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.FachadeApi.Services
{
    public interface IVisitaService
    {
        string BaseUrl { get; }

        Task<IList<int>> GetTopMostAsync();
        Task<IList<VisitaTO>> GetUltimasVisitasAsync(string guidUsuario);
        Task PostVisita(VisitaTO visita);
        
    }

    public class VisitaService : IVisitaService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public VisitaService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:VISITAAPI:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task<IList<VisitaTO>> GetUltimasVisitasAsync(string guidUsuario)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Visita/UltimasVisitas/" + guidUsuario);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList<VisitaTO>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar as visitas para  " + guidUsuario);
            }


        }

        public async Task<IList<int>> GetTopMostAsync()
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Visita/TopMost");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList<int>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar as visitas mais populares");
            }


        }

        public async Task PostVisita(VisitaTO visita)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(visita));

            var response = await http.PostAsync(BaseUrl + "/Visita", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JsonConvert.DeserializeObject<IList<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao adicionar a visita");
            }
        }

       
    }
}