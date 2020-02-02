using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHabitantRuleCheckerService
   {
      Task CheckForInsertAsync(Habitant habitant);
      Task CheckForUpdateAsync(Habitant habitant);
      Task CheckForDeleteAsync(Habitant habitant);
   }
}
