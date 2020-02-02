using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHabitantRepository
   {
      Task InsertAsync(Habitant habitant);
      Task UpdateAsync(Habitant habitant);
      Task DeleteAsync(Habitant habitant);
   }
}
