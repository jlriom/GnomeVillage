using System.Threading.Tasks;

namespace GnomeVillage.Domain.Models
{
   public class HabitantDeleteValidator : HabitantBaseValidator
   {

      public HabitantDeleteValidator(
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHairColorReadonlyRepository hairColorReadonlyRepository,
         IProfessionReadonlyRepository professionReadonlyRepository) :
         base(habitantReadOnlyRepository, hairColorReadonlyRepository, professionReadonlyRepository)
      {
      }

      public async Task Validate(Habitant habitant)
      {
         if (!await ExistHabitantAsync(habitant).ConfigureAwait(false))
         {
            habitant.AddBrokenRule("Habitant not found");
            habitant.Validate("Can not delete habitant");
         }
      }
   }
}
