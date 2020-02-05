using AutoMapper;
using GnomeVillage.Data;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantRepository : Repository<Data.Models.Habitant, Habitant, HabitantId>, IHabitantRepository
   {
      public HabitantRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }
   }
}
