using CSharpFunctionalExtensions;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Contracts
{
   public interface IHabitantReadOnlyRepository
   {
      Task<Maybe<Habitant>> GetSingleAsync(int habitantId);
   }
}
