using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.FachadeApi.Model;

namespace TCCApi.FachadeApi.Services.Recomendacao
{
    public interface ITextoRecomendacaoService
    {
        Task<RecomendacaoSimples> GetAsync(int key);
        Task<IList<string>> PostTextoToTagsAsync(string texto);
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

        public async Task<IList<string>> PostTextoToTagsAsync(string texto)
        {
            var http = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new { Value = texto}), System.Text.Encoding.Default, "application/json");
            //http.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var response = await http.PostAsync(BaseUrl + "/values", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
