using CSharpFunctionalExtensions;

namespace GnomeVillage.Domain.Implementation
{
   public class HairColorReadonlyRepository : IHairColorReadonlyRepository
   {
      public Maybe<HairColor> GetSingle(HairColorId hairColorId)
      {
         throw new System.NotImplementedException();
      }
   }
}
