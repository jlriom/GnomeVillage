using System.Threading.Tasks;

namespace GnomeVillage.Domain.Models
{
   public class HabitantUpdateValidator : HabitantBaseValidator
   {

      public HabitantUpdateValidator(
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHairColorReadonlyRepository hairColorReadonlyRepository,
         IProfessionReadonlyRepository professionReadonlyRepository) :
         base( habitantReadOnlyRepository, hairColorReadonlyRepository, professionReadonlyRepository)
      {
      }

      public async Task Validate(Habitant habitant)
      {
         if (!await ExistHabitantAsync(habitant).ConfigureAwait(false))
            habitant.AddBrokenRule("Habitant not found");

         if (await ExistHabitantWithNameAsync(habitant.Name).ConfigureAwait(false))
            habitant.AddBrokenRule("Habitant with the same name found");

         await CheckCommonDataForUpdateAndInsert(habitant);

         habitant.Validate("Can not update habitant");
      }
   }
}
