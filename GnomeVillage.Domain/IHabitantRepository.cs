using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHabitantRepository
   {
      Task<Habitant> InsertAsync(Habitant habitant);
      Task<Habitant> UpdateAsync(HabitantId habitantId, Habitant habitant);
      Task<Habitant> DeleteAsync(HabitantId habitantId);
   }
}
