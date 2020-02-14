using AutoMapper;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class HabitantNameProfile : Profile
   {
      public HabitantNameProfile()
      {
         CreateMap<HabitantName, string>()
               .ConstructUsing(src => src)
            .ReverseMap()
               .ConstructUsing( src => HabitantName.FromString(src));
      }
   }
}
