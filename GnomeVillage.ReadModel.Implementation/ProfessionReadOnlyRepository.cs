using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Implementation
{
   public class ProfessionReadOnlyRepository : IProfessionReadOnlyRepository
   {
      public IList<Profession> GetAll()
      {
         throw new System.NotImplementedException();
      }
   }
}
