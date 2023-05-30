using BibliotecaTravel.Dtos;
using BibliotecaTravel.Utilidades;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace BibliotecaTest.PruebasUnitarias
{
    public class AuthServiceTest
    {
        private readonly WebApiTest _webApi;
        private readonly HttpClient _client;
        public AuthServiceTest()
        {
            _webApi = new WebApiTest();
            _client = _webApi.CreateClient();
            _client.DefaultRequestHeaders.Clear();
        }

        [SetUp]
        public void Setup()
        {

        }


        [Fact]
        public async Task Auth()
        {
            string token = WebApiTest.Jwt();

            string json = JsonConvert.SerializeObject(new UserDto()
            {
                UserName = "UserBrowser",
                Password ="Travel123"
            }) ;

            var response = await WebApiTest.SendPostAsync("/api/Auth/Auth", json, token, _client);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var resResult = JsonConvert.DeserializeObject<Result>(result);
                Assert.True(resResult?.Error <= 0, result);
            }
            else
            {
                Assert.True(false, response.ReasonPhrase?.ToString());
            }   
        }
    }
}
