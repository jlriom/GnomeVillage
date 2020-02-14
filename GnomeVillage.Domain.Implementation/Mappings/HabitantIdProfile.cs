using AutoMapper;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class HabitantIdProfile: Profile
   {
      public HabitantIdProfile()
      {
         CreateMap<HabitantId, int>().ConstructUsing(src => src);
      }
   }
}
