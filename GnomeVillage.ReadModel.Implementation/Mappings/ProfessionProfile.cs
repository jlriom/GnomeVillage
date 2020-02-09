using AutoMapper;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Implementation.Mappings
{
   public class ProfessionProfile : Profile
   {
      public ProfessionProfile()
      {
         CreateMap<Data.Models.Profession, Profession>();

      }
   }
}
