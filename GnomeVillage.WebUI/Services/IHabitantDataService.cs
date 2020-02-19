using GnomeVillage.Application.Commands.Dtos;
using GnomeVillage.Application.Queries.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.WebUI.Services
{
   public interface IHabitantDataService
   {
      Task<IEnumerable<HabitantViewModel>> GetHabitants();
      Task<HabitantViewModel> GetHabitant(int habitantId);
      Task CreateHabitant(Habitant habitant);
      Task UpdateHabitant(Habitant habitant);
      Task DeleteHabitant(int habitantId);
   }
}
