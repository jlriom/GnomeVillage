using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Contracts
{
   public interface IHairColorReadonlyRepository
   {
      Task<IList<HairColor>> GetAllAsync();
   }
}
