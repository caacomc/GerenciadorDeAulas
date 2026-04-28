using System.Text;
using System.Text.Json;

using Escola_Models;

namespace GerenciadorDeAulas.Services
{
    public class LoginService
    {
        private readonly string _apiUrl = Secrets.Api;
        private static readonly HttpClient _client = new HttpClient();

        public async Task<Usuario?> Login(string nome, string senha) 
        {
            var loginDados = new { NomeUsuario = nome, Senha = senha };

            string json = JsonSerializer.Serialize(loginDados);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_apiUrl}verificar/login", content);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Usuario>(result, options);
            }
            return null;
        }
    }
}
