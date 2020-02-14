using AutoMapper;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class HairColorIdProfile: Profile
   {
      public HairColorIdProfile()
      {
         CreateMap<HairColorId, string>()
               .ConstructUsing(src => src)
            .ReverseMap()
               .ConstructUsing( src => new HairColorId(src));
      }
   }
}
