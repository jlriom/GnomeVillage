using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IProfessionReadonlyRepository
   {
      Task<Maybe<Profession>> FindAsync(ProfessionId professionId);
      Task<IList<Profession>> GetAllAsync();
   }
}
