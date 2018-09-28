using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Models;
using TCCApi.FachadeApi.Utils;

namespace TCCApi.FachadeApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly SharedInfo sharedInfo;
        private readonly string baseUrl;

        public AuthService(IConfiguration configuration,SharedInfo sharedInfo)
        {
            this.configuration = configuration;
            this.sharedInfo = sharedInfo;
            baseUrl = configuration.GetSection("apisUrls:AUTHAPI:url").Get<string>();
        }
        public string BaseUrl { get => baseUrl; }

        public async Task<Usuario> GetUsuarioLogadoAsync()
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", $"{sharedInfo.Token}");
            var response = await http.GetAsync(BaseUrl + "/connect/userinfo");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuario>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            else
            {
                throw new Exception("Falha ao buscar a Compra ");
            }


        }

        public async Task<Empresa> GetEmpresaLogadoAsync()
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", $"{sharedInfo.Token}");
            var response = await http.GetAsync(BaseUrl + "/connect/userinfo");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Empresa>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            else
            {
                throw new Exception("Falha ao buscar a Compra ");
            }


        }

        public async Task<ApplicationUserTO> PostUsuario(ApplicationUserTO compra)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(compra),Encoding.Default, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Auth/Usuario", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApplicationUserTO>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var teste = await response.Content.ReadAsStringAsync();
                throw new ArgumentException(teste);
            }
        }

        public async Task<ApplicationUserTO> PostEmpresa(ApplicationUserTO compra)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(compra), Encoding.Default, "application/json");

            var response = await http.PostAsync(BaseUrl + "/api/Auth/Empresa", content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ReasonPhrase);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApplicationUserTO>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<TokenResult> DoLogin(string email, string password, string type)
        {
            var http = new HttpClient();
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>{
                new KeyValuePair<string, string>("username", email),
new KeyValuePair<string, string>("password",password),
new KeyValuePair<string, string>("grant_type","password"),
new KeyValuePair<string, string>("client_Id","service.client"),
new KeyValuePair<string, string>("client_secret","secret"),
new KeyValuePair<string, string>("scope",$"{type}.profile openid")
            });
            //content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");


            //var content = new StringContent(JsonConvert.SerializeObject());

            var response = await http.PostAsync(BaseUrl + "/connect/token", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TokenResult>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Falha ao adicionar a visita");
            }
        }
    }
}
