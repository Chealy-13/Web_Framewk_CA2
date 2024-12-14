using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Web_Framewk_CA2.Components.Model;

namespace Web_Framewk_CA2.Components.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider, IAccountManagement
    {
        private bool _Authenticated = false;

        private readonly ClaimsPrincipal Unauthenticated =
            new(new ClaimsIdentity());

        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(IHttpClientFactory httpClientFactory)
        {
           _httpClient =  httpClientFactory.CreateClient("Auth");
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _Authenticated = false;

            //default to not authenticated
            var user = Unauthenticated;

            return new AuthenticationState(user);

        }

        public async Task<FormResult> RegisterAsync(string email, string password)
        {
            string[] defaultDetail = ["An unknown error prevented registration from succeeding"];

            try
            {
                var result =  await _httpClient.PostAsJsonAsync("register",
                    new {email, password});
                if (result.IsSuccessStatusCode)
                {
                    return new FormResult { Succeeded = true };
                }

                var details = await result.Content.ReadAsStringAsync();
                var problemDetails = JsonDocument.Parse(details);
                var errors = new List<string>();
                var errorList = problemDetails.RootElement.GetProperty("errors");

                foreach (var errorEntry in errorList.EnumerateObject())
                {
                    if (errorEntry.Value.ValueKind == JsonValueKind.String)
                    {
                        errors.Add(errorEntry.Value.GetString()!);
                    }
                    else if (errorEntry.Value.ValueKind == JsonValueKind.Array)
                    {
                        errors.AddRange(
                            errorEntry.Value.EnumerateArray().Select(
                                e => e.GetString() ?? string.Empty)
                            .Where(e => !string.IsNullOrEmpty(e) ) );
                    }
                }
                return new FormResult
                {
                    Succeeded = false,
                    ErrorList = problemDetails == null ? defaultDetail : [.. errors]
                };
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
