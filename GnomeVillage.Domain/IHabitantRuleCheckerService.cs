using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHabitantRuleCheckerService
   {
      Task<Habitant> CheckForInsertAsync(Habitant habitant);
      Task<Habitant> CheckForUpdateAsync(Habitant habitant);
      Task<Habitant> CheckForDeleteAsync(Habitant habitant);
   }
}
