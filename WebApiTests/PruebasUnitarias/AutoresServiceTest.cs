using BibliotecaTest;
using BibliotecaTravel.Dtos;
using BibliotecaTravel.Utilidades;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace WebApiTests.PruebasUnitarias
{
    public class AutoresServiceTest
    {
        private readonly WebApiTest _webApi;
        private readonly HttpClient _client;
        public AutoresServiceTest()
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
        public async Task Autores()
        {
            string token = WebApiTest.Jwt();

            var response = await WebApiTest.SendGetAsync("/api/Autores/Autores", token, _client);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Assert.True(result!= null , result);
            }
            else
            {
                Assert.True(false, response.ReasonPhrase?.ToString());
            }
        }

        [Fact]
        public async Task AddAutor()
        {
            string token = WebApiTest.Jwt();

            string json = JsonConvert.SerializeObject(new AutoreDto()
            {
                Nombre = "jaime",
                Apellidos = "Ricaute"
            });

            var response = await WebApiTest.SendPostAsync("/api/Autores/AddAutor", json, token, _client);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Assert.True(result != null, result);
            }
            else
            {
                Assert.True(false, response.ReasonPhrase?.ToString());
            }
        }
    }
}
