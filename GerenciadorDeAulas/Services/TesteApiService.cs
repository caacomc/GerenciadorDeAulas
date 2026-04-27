using Escola_Models;
using Newtonsoft.Json;

namespace GerenciadorDeAulas.Services
{
    public class TesteApiService
    {
        private readonly string _apiUrl = Secrets.Api;
        private static readonly HttpClient _client = new HttpClient();

        public async Task<Usuario?> GetUser(string Nome)
        {
            try
            {
                string URL = $"{_apiUrl}verificar/{Nome}";

                var response = await _client.GetAsync(URL);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(json);
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);    
            }
            return null;
        }
    }
}
