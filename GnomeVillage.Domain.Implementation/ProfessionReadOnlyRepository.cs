using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class ProfessionReadOnlyRepository : IProfessionReadOnlyRepository
   {
      public async Task<Maybe<Profession>> GetSingle(ProfessionId professionId)
      {
         throw new System.NotImplementedException();
      }
   }
}
