using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantReadOnlyRepository : IHabitantReadOnlyRepository
   {
      public async Task<Maybe<Habitant>> GetSingleAsync(HabitantId habitantId)
      {
         throw new System.NotImplementedException();
      }
   }
}
