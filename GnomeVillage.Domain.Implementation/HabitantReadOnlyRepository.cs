using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantReadOnlyRepository : Repository <Data.Models.Habitant, int, Habitant, HabitantId>, IHabitantReadOnlyRepository
   {

      public HabitantReadOnlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }

      public async Task<Maybe<Habitant>> GetSingleAsync(HabitantId habitantId)
      {
         return await base.FindAsync(habitantId);
      }

      public  async Task<Maybe<Habitant>> GetSingleAsync(HabitantName habitantName)
      {
         var found = await base.GetAsync( h => h.Name == habitantName).ConfigureAwait(false);

         return found.Any()
            ? Maybe<Habitant>.From(found.First())
            : Maybe<Habitant>.None;
      }

      public async Task<Maybe<Habitant>> GetOtherHabitantWithNameSingleAsync(HabitantName habitantName, HabitantId habitantId)
      {
         var found = await base.GetAsync(h => h.Name == habitantName && h.Id != habitantId).ConfigureAwait(false);

         return found.Any()
            ? Maybe<Habitant>.From(found.First())
            : Maybe<Habitant>.None;
      }
   }
}
