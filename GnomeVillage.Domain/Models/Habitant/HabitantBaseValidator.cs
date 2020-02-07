using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Models
{
   public abstract class HabitantBaseValidator
   {
      private readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;
      private readonly IHairColorReadonlyRepository hairColorReadonlyRepository;
      private readonly IProfessionReadonlyRepository professionReadonlyRepository;

      protected HabitantBaseValidator(
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHairColorReadonlyRepository hairColorReadonlyRepository,
         IProfessionReadonlyRepository professionReadonlyRepository)
      {
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
         this.hairColorReadonlyRepository = hairColorReadonlyRepository;
         this.professionReadonlyRepository = professionReadonlyRepository;
      }

      protected async Task<bool> ExistHabitantAsync(Habitant habitant)
      {
         return (await habitantReadOnlyRepository.GetSingleAsync(habitant.Id).ConfigureAwait(false)).HasValue;
      }

      protected async Task<bool> ExistHabitantWithNameAsync(HabitantName habitantName)
      {
         return (await habitantReadOnlyRepository.GetSingleAsync(habitantName).ConfigureAwait(false)).HasValue;
      }


      protected async Task<bool> ExistHairColorForHabitant(Habitant habitant)
      {
         return (await hairColorReadonlyRepository.FindAsync(habitant.HairColor.Id).ConfigureAwait(false)).HasValue;
      }

      protected async Task<bool> ExistProfessionsForHabitant(Habitant habitant)
      {
         var allProfessions = await professionReadonlyRepository.GetAllAsync().ConfigureAwait(false);

         return allProfessions.All(p => habitant.Professions.Contains(p));
      }

      protected async Task CheckCommonDataForUpdateAndInsert(Habitant habitant)
      {
         if (!await ExistHairColorForHabitant(habitant).ConfigureAwait(false))
         {
            habitant.AddBrokenRule("Defined Hair Color for habitant does not exist");
         }

         if (!await ExistProfessionsForHabitant(habitant).ConfigureAwait(false))
         {
            habitant.AddBrokenRule("Defined Professions for habitant does not exist");
         }

         foreach (var friend in habitant.Friends)
         {
            if (!await ExistHabitantWithNameAsync(friend).ConfigureAwait(false))
            {
               habitant.AddBrokenRule($"Friend '{friend}' not found");
            }
         }
      }

   }
}
