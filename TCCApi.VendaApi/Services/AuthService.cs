using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TCCApi.VendaApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public string BaseUrl { get; }

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;

            BaseUrl = configuration.GetSection("pagseguro:api").Get<string>();
        }
        ///v1/oauth2/token
        ///
        public async Task<string> AuthenticateAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "/sessions");
            var secret = _configuration.GetSection("pagseguro:token").Get<string>();
            var email = _configuration.GetSection("pagseguro:email").Get<string>();
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                email = email,
                token = secret
            }));

            var response = client.SendAsync(request);
            

        }

        public class Session
        {
            public string Id { get; set; }
        }

       
    }

    public class TransactionService
    {
        private readonly IConfiguration _configuration;

        public string BaseUrl { get; }

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;

            BaseUrl = configuration.GetSection("pagseguro:api").Get<string>() + "/transactions";

        }
    }
}
