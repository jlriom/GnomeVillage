using CSharpFunctionalExtensions;

namespace GnomeVillage.Domain
{
   public interface IHabitantReadOnlyRepository
   {
      Maybe<Habitant> GetSingle(HabitantId habitantId);
   }
}
