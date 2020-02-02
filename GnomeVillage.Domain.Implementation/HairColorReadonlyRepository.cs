using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HairColorReadonlyRepository : IHairColorReadonlyRepository
   {
      public async Task<Maybe<HairColor>> GetSingleAsync(HairColorId hairColorId)
      {
         throw new System.NotImplementedException();
      }
   }
}
