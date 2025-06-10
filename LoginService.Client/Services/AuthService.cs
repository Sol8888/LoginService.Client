using System.Net.Http.Json;
using LoginService.Client.Models;


namespace LoginService.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/login", request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                return $"Bienvenido, {result?.Username}";
            }

            return "Credenciales inválidas.";
        }

        private class LoginResult
        {
            public string Message { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
        }
    }
}
