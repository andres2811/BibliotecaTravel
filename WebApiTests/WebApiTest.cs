using BibliotecaTravel;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BibliotecaTest
{
    class WebApiTest : WebApplicationFactory<Program>
    {
        public static string Jwt()
        {
            Dictionary<string, string> claims = new();
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes("SecretKey10125779374235322"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claimsIdentity = new ClaimsIdentity();
            if (claims.Count > 0)
            {
                foreach (KeyValuePair<string, string> claim in claims)
                    claimsIdentity.AddClaim(new Claim(claim.Key, claim.Value));
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: "http://localhost:4200",
                issuer: "https://localhost:44341",
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(262800),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        public static async Task<HttpResponseMessage> SendPostAsync(string url, string request, string token, HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var buffer = System.Text.Encoding.UTF8.GetBytes(request);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await client.PostAsync(url, byteContent);
        }

        public static async Task<HttpResponseMessage> SendGetAsync(string url, string token, HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            return await client.GetAsync(url);
        }
    }
}
