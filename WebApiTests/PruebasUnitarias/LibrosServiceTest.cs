using BibliotecaTest;
using BibliotecaTravel.Dtos;
using BibliotecaTravel.Utilidades;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Assert = NUnit.Framework.Assert;


namespace WebApiTests.PruebasUnitarias
{
    public class LibrosServiceTest
    {
        private readonly WebApiTest _webApi;
        private readonly HttpClient _client;
        public LibrosServiceTest()
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
        public async Task LibrosConAutores()
        {
            string token = WebApiTest.Jwt();

            var response = await WebApiTest.SendGetAsync("/api/Libros/LibrosConAutores/1", token, _client);

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
        public async Task AddLibro()
        {
            string token = WebApiTest.Jwt();
            var list = new List<int> { 1, 2 };

            string json = JsonConvert.SerializeObject(new LibroCreacionDto()
            {
                IdEditorial = 1,
                Titulo = "prueba",
                Sinopsis = "prueba",
                N_paginas = "prueba",
                AutoresId = list
            });

            var response = await WebApiTest.SendPostAsync("/api/Libros/AddLibro", json, token, _client);

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
