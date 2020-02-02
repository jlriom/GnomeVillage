using CSharpFunctionalExtensions;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Contracts
{
   public interface IHabitantReadOnlyRepository
   {
      Maybe<Habitant> GetSingle(int habitantId);
   }
}
