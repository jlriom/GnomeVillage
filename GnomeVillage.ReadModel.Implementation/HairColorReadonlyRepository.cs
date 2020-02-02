using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HairColorReadonlyRepository : IHairColorReadonlyRepository
   {
      public IList<HairColor> GetAll()
      {
         throw new System.NotImplementedException();
      }
   }
}
