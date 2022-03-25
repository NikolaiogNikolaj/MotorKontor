
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;

namespace MotorKontor.UI.Helpers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRunetime;
        public CustomAuthStateProvider( IJSRuntime jSRuntime)
        {
            _jsRunetime = jSRuntime;
        }

        // Okay Winther, som jeg har forstået her så nedarver vi AuthenticationStateProvider sp vi kan ovverride GetAuthenticationStateAsync
        // Vi modtager en JWT hvor vi skal parse payloaden af JWT via Split(".")[1]   Jwt består af 3 dele opdelt via punktum. Indermaden ryger igennem base64 Decoding.
        // Next smider Serializer vi det i en dictionary som matcher med en key... Spændene stuff.. og returner keyvaluepairs hvor vi også opretter en ny claim. Forstår selv ikke 50% af dette :))
        // Kort sagt, dette er logikken som gør at hvis man ikke er logget ind (ikke har en JWT i localStorage) så kan man kun se Unauthorized stuff som ligger i selve html på de forskellige pages
        // Hvor derimod man har en jwt, så kan man godt se de authorized stuff

        // Link til den guide jeg har brugt https://www.youtube.com/watch?v=Yh16E2u2pio


        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await GetTokenAsync();
            var identity = new ClaimsIdentity();

            if(!string.IsNullOrEmpty(token))
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public async Task<string> GetTokenAsync()
            => await _jsRunetime.InvokeAsync<string>("localStorage.getItem", "Token");
        

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch(base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
