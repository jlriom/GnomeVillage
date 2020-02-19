using GnomeVillage.Application.Commands.Dtos;
using GnomeVillage.Application.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GnomeVillage.WebUI.Services
{
   public class HabitantDataService : IHabitantDataService
   {
      private readonly HttpClient httpClient;
      private const string baseUrl = "/api/Habitant";

      private readonly JsonSerializerOptions jsonSerializerOptions 
         = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

      public HabitantDataService(HttpClient httpClient)
      {
         this.httpClient = httpClient;
      }

      public Task CreateHabitant(Habitant habitant)
      {
         throw new NotImplementedException();
      }

      public Task DeleteHabitant(int habitantId)
      {
         throw new NotImplementedException();
      }

      public async Task<HabitantViewModel> GetHabitant(int habitantId)
      {
         return await JsonSerializer.DeserializeAsync<HabitantViewModel>
               (await httpClient.GetStreamAsync($"{baseUrl}/{habitantId}"), jsonSerializerOptions);
      }

      public async Task<IEnumerable<HabitantViewModel>> GetHabitants()
      {
         // TODO
         var limit = 40;
         var offset = 0;
         return await JsonSerializer.DeserializeAsync<IEnumerable<HabitantViewModel>>
               (await httpClient.GetStreamAsync($"{baseUrl}/{limit}/{offset}"), jsonSerializerOptions);
      }

      public Task UpdateHabitant(Habitant habitant)
      {
         throw new NotImplementedException();
      }
   }
}
