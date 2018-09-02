using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services
{




    public interface IEventoCrudService
    {
        Task<Evento> GetAsync(int key);
        Task<IList<Evento>> GetAllAsync();
        Task<IList<Evento>> GetPorEmpresaAsync(int key);
        Task<Evento> PostAsync(Evento evento);
        Task<Evento> PutAsync(Evento evento);
    }

    public class EventoCrudService : IEventoCrudService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public EventoCrudService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:CRUDAPI:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task<IList<Evento>> GetAllAsync()
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/evento");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList< Evento >>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento ");
            }
        }

        public async Task<Evento> GetAsync(int key)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Evento/" + key);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Evento>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento " + key);
            }


        }

        public async Task<IList<Evento>> GetPorEmpresaAsync(int key)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Evento/Empresa/" + key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList<Evento>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento " + key);
            }


        }
        public async Task<Evento> PostAsync(Evento evento)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(evento),System.Text.Encoding.Default, "application/json");
            //http.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var response = await http.PostAsync(BaseUrl + "/Evento",content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Evento>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento " );
            }
        }

        public async Task<Evento> PutAsync(Evento evento)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(evento));
            var response = await http.PutAsync(BaseUrl + "/Evento", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Evento>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar o Evento ");
            }
        }
    }
}
