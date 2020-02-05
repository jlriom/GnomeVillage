using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IHairColorReadonlyRepository
   {
      Task<Maybe<HairColor>> FindAsync(HairColorId hairColorId);
      Task<IList<HairColor>> GetAllAsync();
   }
}
