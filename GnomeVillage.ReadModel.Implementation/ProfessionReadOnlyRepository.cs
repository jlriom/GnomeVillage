using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Implementation
{
   public class ProfessionReadOnlyRepository : IProfessionReadOnlyRepository
   {
      private readonly GnomeVillageContext Context;

      public ProfessionReadOnlyRepository(GnomeVillageContext context)
      {
         Context = context;
      }

      public async Task<IList<Profession>> GetAllAsync()
      {
         var professions = Context.Profession.ToList();

         return await Task.FromResult(new List<Profession>());
      }
   }
}
