using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantReadOnlyRepository : Repository <Data.Models.Habitant, Habitant, HabitantId>, IHabitantReadOnlyRepository
   {

      public HabitantReadOnlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }

      public async Task<Maybe<Habitant>> GetSingleAsync(HabitantId habitantId)
      {
         return await base.FindAsync(habitantId);
      }
   }
}
