using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HairColorReadonlyRepository : IHairColorReadonlyRepository
   {

      private readonly GnomeVillageContext Context;

      public HairColorReadonlyRepository(GnomeVillageContext context)
      {
         Context = context;
      }


      public async Task<IList<HairColor>> GetAllAsync()
      {
         var hairColors = Context.HairColor.ToList();

         return await Task.FromResult(new List<HairColor>());
      }
   }
}
