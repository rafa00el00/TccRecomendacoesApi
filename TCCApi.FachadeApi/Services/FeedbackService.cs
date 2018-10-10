using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.FachadeApi.Services
{
    public interface IFeedbackService
    {
        string BaseUrl { get; }

        Task<Feedback> GetAsync(int key);
        Task<IList<Feedback>> GetListaFeedBacks(string guidEvento);
        Task<Feedback> PostFeedback(Feedback compra);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public FeedbackService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:FEEDBACKAPI:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task<Feedback> GetAsync(int key)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/FeedBack/" + key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Feedback>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar a Compra " + key);
            }


        }

        public async Task<Feedback> PostFeedback(Feedback compra)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(compra), Encoding.Default, "application/json");

            var response = await http.PostAsync(BaseUrl + "/FeedBack", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Feedback>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao adicionar a visita");
            }
        }

        public async Task<IList<Feedback>> GetListaFeedBacks(string guidEvento)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/FeedBack/Evento/" + guidEvento);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList<Feedback>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar as Compras para " + guidEvento);
            }
        }

    }
}
