using AutoMapper;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Implementation.Mappings
{
   public class HairColorProfile: Profile
   {
      public HairColorProfile()
      {
         CreateMap<Data.Models.HairColor, HairColor>();

      }
   }
}
