using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHairColorReadonlyRepository
   {
      Task<Maybe<HairColor>> GetSingleAsync(HairColorId hairColorId);
   }
}
