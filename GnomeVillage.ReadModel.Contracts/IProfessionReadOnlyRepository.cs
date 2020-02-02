using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Contracts
{
   public interface IProfessionReadOnlyRepository
   {
      Task<IList<Profession>> GetAllAsync();
   }
}
