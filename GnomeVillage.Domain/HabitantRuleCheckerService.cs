using GnomeVillage.Domain.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantRuleCheckerService : IHabitantRuleCheckerService
   {
      private readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;
      private readonly IHairColorReadonlyRepository hairColorReadonlyRepository;
      private readonly IProfessionReadonlyRepository professionReadonlyRepository;

      public HabitantRuleCheckerService(
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHairColorReadonlyRepository hairColorReadonlyRepository,
         IProfessionReadonlyRepository professionReadonlyRepository)
      {
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
         this.hairColorReadonlyRepository = hairColorReadonlyRepository;
         this.professionReadonlyRepository = professionReadonlyRepository;
      }
      public async Task<Habitant> CheckForDeleteAsync(Habitant habitant)
      {
         List<BrokenRule> brokenRules = new List<BrokenRule>();

         if (!await ExistHabitantAsync(habitant).ConfigureAwait(false))
         {
            brokenRules.Add(new BrokenRule("Habitant not found"));
         }

         habitant.Validate("Can not delete habitant", brokenRules);

         return habitant;
      }

      public async Task<Habitant> CheckForInsertAsync(Habitant habitant)
      {
         List<BrokenRule> brokenRules = new List<BrokenRule>();

         if (await ExistHabitantWithNameAsync(habitant.Name).ConfigureAwait(false))
         {
            brokenRules.Add(new BrokenRule("Habitant with the same name found"));
         }

         await CheckCommonDataForUpdateAndInsert(habitant, brokenRules);

         habitant.Validate("Can not create habitant", brokenRules);

         return habitant;

      }

      public async Task<Habitant> CheckForUpdateAsync(Habitant habitant)
      {
         List<BrokenRule> brokenRules = new List<BrokenRule>();

         if (!await ExistHabitantAsync(habitant).ConfigureAwait(false))
         {
            brokenRules.Add(new BrokenRule("Habitant not found"));
         }

         await CheckCommonDataForUpdateAndInsert(habitant, brokenRules);

         habitant.Validate("Can not create habitant", brokenRules);

         return habitant;
      }

      private async Task CheckCommonDataForUpdateAndInsert(Habitant habitant, List<BrokenRule> brokenRules)
      {
         if (!await ExistHairColorForHabitant(habitant).ConfigureAwait(false))
         {
            brokenRules.Add(new BrokenRule("Defined Hair Color for habitant does not exist"));
         }

         if (!await ExistProfessionsForHabitant(habitant).ConfigureAwait(false))
         {
            brokenRules.Add(new BrokenRule("Defined Professions for habitant does not exist"));
         }

         foreach (var friend in habitant.Friends)
         {
            if (!await ExistHabitantWithNameAsync(friend).ConfigureAwait(false))
            {
               brokenRules.Add(new BrokenRule($"Friend '{friend}' not found"));
            }
         }
      }

      private async Task<bool> ExistHabitantAsync(Habitant habitant)
      {
         return (await this.habitantReadOnlyRepository.GetSingleAsync(habitant.Id).ConfigureAwait(false)).HasValue;
      }

      private async Task<bool> ExistHabitantWithNameAsync(HabitantName habitantName)
      {
         return (await this.habitantReadOnlyRepository.GetSingleAsync(habitantName).ConfigureAwait(false)).HasValue;
      }


      private async Task<bool> ExistHairColorForHabitant( Habitant habitant)
      {
         return (await this.hairColorReadonlyRepository.FindAsync(habitant.HairColor.Id).ConfigureAwait(false)).HasValue;
      }

      private async Task<bool> ExistProfessionsForHabitant(Habitant habitant)
      {
         var allProfessions = await this.professionReadonlyRepository.GetAllAsync().ConfigureAwait(false);

         return allProfessions.All(p => habitant.Professions.Contains(p));
      }
   }
}
