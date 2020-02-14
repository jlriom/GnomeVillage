using AutoMapper;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class ProfessionIdProfile: Profile
   {
      public ProfessionIdProfile()
      {
         CreateMap<ProfessionId, string>()
               .ConstructUsing(src => src)
            .ReverseMap()
               .ConstructUsing(src => new ProfessionId(src));
      }
   }
}
