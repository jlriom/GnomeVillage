using CSharpFunctionalExtensions;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HabitantReadOnlyRepository : IHabitantReadOnlyRepository
   {
      public Maybe<Habitant> GetSingle(int habitantId)
      {
         throw new System.NotImplementedException();
      }
   }
}
