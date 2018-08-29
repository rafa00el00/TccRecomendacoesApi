using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model.TO;

namespace TCCApi.FachadeApi.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IConfiguration configuration;
        private readonly string baseUrl;

        public EmpresaService(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseUrl = configuration.GetSection("apisUrls:CRUDAPI:url").Get<string>();
        }

        public string BaseUrl { get => baseUrl; }

        public async Task<Empresa> GetEmpresa(int id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(BaseUrl + "/Empresa/"+ id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Empresa>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao buscar as visitas mais populares");
            }


        }

        public async Task PostEmpresa(Empresa empresa)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(empresa));

            var response = await http.PostAsync(BaseUrl + "/Empresa", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JsonConvert.DeserializeObject<IList<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao adicionar a visita");
            }
        }

        public async Task PatchEmpresa(Empresa empresa)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(empresa));

            var response = await http.PutAsync(BaseUrl + "/Empresa", content);

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