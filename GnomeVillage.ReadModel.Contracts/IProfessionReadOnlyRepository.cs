using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Contracts
{
   public interface IProfessionReadOnlyRepository
   {
      IList<Profession> GetAll();
   }
}
