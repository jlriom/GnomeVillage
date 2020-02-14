using AutoMapper;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class ProfessionProfile: Profile
   {
      public ProfessionProfile()
      {
         CreateMap<Profession, Data.Models.Profession>()
            .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Id))
        .ReverseMap()
            .ConstructUsing(src => new Profession(new ProfessionId(src.Name)));
      }
   }
}
