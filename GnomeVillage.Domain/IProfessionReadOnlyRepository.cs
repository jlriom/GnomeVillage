using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain
{
   public interface IProfessionReadOnlyRepository
   {
      Task<Maybe<Profession>> GetSingle(ProfessionId professionId);
   }
}
