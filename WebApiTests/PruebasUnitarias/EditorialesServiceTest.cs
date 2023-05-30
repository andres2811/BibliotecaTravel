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
    public class EditorialesServiceTest
    {
        private readonly WebApiTest _webApi;
        private readonly HttpClient _client;
        public EditorialesServiceTest()
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
        public async Task Editoriales()
        {
            string token = WebApiTest.Jwt();

            var response = await WebApiTest.SendGetAsync("/api/Editoriales/Editoriales", token, _client);

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

        [Fact]
        public async Task AddEditorial()
        {
            string token = WebApiTest.Jwt();

            string json = JsonConvert.SerializeObject(new EditorialeDto()
            {
                Nombre = "Normal Edit",
                Sede = "sur"
            });

            var response = await WebApiTest.SendPostAsync("/api/Editoriales/AddEditorial", json, token, _client);

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
