using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PayPal.Api;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TCCApi.VendaApi.Models;

namespace TCCApi.VendaApi.Services
{
    public class TransactionService
    {
        private readonly IConfiguration _configuration;

        public string BaseUrl { get; }

        public TransactionService(IConfiguration configuration)
        {
            _configuration = configuration;

            BaseUrl = configuration.GetSection("pagseguro:api").Get<string>() + "/transactions";

        }


        private async Task<HttpResponseMessage> PostTransactionAsync(HttpContent content)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            request.Content = content;

            var response = await client.SendAsync(request);

            return response;
        }

        public async Task<Transaction> PostBoletoAsync(BoletoTransaction boletoTransaction)
        {
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            boletoTransaction.Email = email;
            boletoTransaction.token = secret;
            var content = new StringContent(JsonConvert.SerializeObject(boletoTransaction));
            var response = await PostTransactionAsync(content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Transaction>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<Transaction> PostDebitoAsync(DebitoTransaction boletoTransaction)
        {
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            boletoTransaction.Email = email;
            boletoTransaction.token = secret;
            var content = new StringContent(JsonConvert.SerializeObject(boletoTransaction));
            var response = await PostTransactionAsync(content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Transaction>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }


        public async Task<Transaction> PostCreditoAsync(CreditoTransaction boletoTransaction)
        {
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            boletoTransaction.Email = email;
            boletoTransaction.token = secret;
            var content = new StringContent(JsonConvert.SerializeObject(boletoTransaction));
            var response = await PostTransactionAsync(content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Transaction>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<Models.RetornoBusca.TransactionSearchResult> GetTransactionAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                email = email,
                token = secret
            }));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Models.RetornoBusca.TransactionSearchResult>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        public async Task<Models.RetornoBusca.TransactionSearchResult> GetTransactionAsync(string reference)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                email = email,
                token = secret,
                reference
            }));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Models.RetornoBusca.TransactionSearchResult>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        public async Task<Models.RetornoBusca.TransactionSearchResult> GetTransactionByCodigoAsync(string CodTransacao)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + "/"+ CodTransacao);
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                email = email,
                token = secret
            }));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Models.RetornoBusca.TransactionSearchResult>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }


    }
}
