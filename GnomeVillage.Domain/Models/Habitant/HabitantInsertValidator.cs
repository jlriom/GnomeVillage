using System.Threading.Tasks;

namespace GnomeVillage.Domain.Models
{
   public class HabitantInsertValidator: HabitantBaseValidator
   {

      public HabitantInsertValidator(
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHairColorReadonlyRepository hairColorReadonlyRepository,
         IProfessionReadonlyRepository professionReadonlyRepository): 
         base(habitantReadOnlyRepository, hairColorReadonlyRepository, professionReadonlyRepository)
      {
      }

      public async Task Validate(Habitant habitant)
      {
         if (await ExistHabitantWithNameAsync(habitant.Name).ConfigureAwait(false))
            habitant.AddBrokenRule("Habitant with the same name found");

         await CheckCommonDataForUpdateAndInsert(habitant);

         habitant.Validate("Can not create habitant");
      }
   }
}
