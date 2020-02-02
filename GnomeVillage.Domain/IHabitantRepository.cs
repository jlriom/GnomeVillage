using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHabitantRepository
   {
      Task<Habitant> InsertAsync(Habitant habitant);
      Task<Habitant> UpdateAsync(Habitant habitant);
      Task<Habitant> DeleteAsync(Habitant habitant);
   }
}
