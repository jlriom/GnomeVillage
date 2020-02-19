using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GnomeVillage.WebUI.Services
{
   public class LookupDataService : ILookupDataService
   {
      private readonly HttpClient httpClient;
      private const string baseUrl = "/api/Lookupdata";

      private readonly JsonSerializerOptions jsonSerializerOptions
         = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

      public LookupDataService(HttpClient httpClient)
      {
         this.httpClient = httpClient;
      }

      public async Task<IEnumerable<string>> GetAllHairColors()
      {
         return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
            (await httpClient.GetStreamAsync($"{baseUrl}/haircolor"), jsonSerializerOptions);
      }

      public async Task<IEnumerable<string>> GetAllProfessions()
      {
         return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
            (await httpClient.GetStreamAsync($"{baseUrl}/profession"), jsonSerializerOptions);
      }
   }
}
