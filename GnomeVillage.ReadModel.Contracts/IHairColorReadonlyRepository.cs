using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Contracts
{
   public interface IHairColorReadonlyRepository
   {
      IList<HairColor> GetAll();
   }
}
