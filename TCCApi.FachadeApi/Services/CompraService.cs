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

    public class CompraService : ICompraService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public CompraService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:VENDASAPI:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task<Compra> GetAsync(int key)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Compra/" + key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Compra>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar a Compra " + key);
            }


        }

        public async Task<Compra> PostCompra(Compra compra)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(compra),Encoding.Default,"application/json");

            var response = await http.PostAsync(BaseUrl + "/Compra", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Compra>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao adicionar a visita");
            }
        }

        public async Task<IList<Compra>> GetListaCompras(string guidUsuario)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Compra/Usuario/" + guidUsuario);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IList<Compra>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar as Compras para " + guidUsuario);
            }
        }

    }
}
