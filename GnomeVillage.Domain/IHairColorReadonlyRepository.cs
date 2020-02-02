using CSharpFunctionalExtensions;

namespace GnomeVillage.Domain
{
   public interface IHairColorReadonlyRepository
   {
      Maybe<HairColor> GetSingle(HairColorId hairColorId);
   }
}
