using CSharpFunctionalExtensions;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantReadOnlyRepository : IHabitantReadOnlyRepository
   {
      public Maybe<Habitant> GetSingle(HabitantId habitantId)
      {
         throw new System.NotImplementedException();
      }
   }
}
