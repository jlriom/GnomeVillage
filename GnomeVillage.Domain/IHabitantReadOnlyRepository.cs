using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHabitantReadOnlyRepository
   {
      Task<Maybe<Habitant>> GetSingleAsync(HabitantId habitantId);
      Task<Maybe<Habitant>> GetSingleAsync(HabitantName habitantName);
   }
}
