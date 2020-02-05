using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HabitantReadOnlyRepository : ReadonlyBaseRepository<Data.Models.Habitant, Habitant>, IHabitantReadOnlyRepository
   {

      public HabitantReadOnlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }

      public async Task<Paging<Habitant>> GetAsync(int limit, int offset)
      {
         return await base.GetAsync(habitant => true, h => h.Name, limit, offset);
      }

      public async Task<Maybe<Habitant>> GetSingleAsync(int habitantId)
      {
         return await base.FindAsync(habitantId);
      }
   }
}
