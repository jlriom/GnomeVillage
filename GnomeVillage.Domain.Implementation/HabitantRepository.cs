using AutoMapper;
using GnomeVillage.Data;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public class HabitantRepository : Repository<Data.Models.Habitant, int, Habitant, HabitantId>, IHabitantRepository
   {
      public HabitantRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }
   }
}
