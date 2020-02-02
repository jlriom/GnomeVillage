using CSharpFunctionalExtensions;

namespace GnomeVillage.Domain
{
   public interface IProfessionReadOnlyRepository
   {
      Maybe<Profession> GetSingle(ProfessionId professionId);
   }
}
