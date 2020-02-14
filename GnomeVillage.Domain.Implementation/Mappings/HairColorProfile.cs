using AutoMapper;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class HairColorProfile : Profile
   {
      public HairColorProfile()
      {
         CreateMap<HairColor, Data.Models.HairColor>()
            .ForMember(dest => dest.Name, src => src.MapFrom(h => h.Id))
        .ReverseMap()
            .ConstructUsing( src =>  new HairColor(new HairColorId( src.Name)));
      }
   }
}
