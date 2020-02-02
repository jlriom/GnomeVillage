using CSharpFunctionalExtensions;

namespace GnomeVillage.Domain.Implementation
{
   public class ProfessionReadOnlyRepository : IProfessionReadOnlyRepository
   {
      public Maybe<Profession> GetSingle(ProfessionId professionId)
      {
         throw new System.NotImplementedException();
      }
   }
}
