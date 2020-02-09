using AutoMapper;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.ReadModel.Implementation.Mappings
{
   public class HabitantProfile: Profile
   {
      public HabitantProfile()
      {
         CreateMap<Data.Models.HabitantProfessions, Profession>()
            .ForMember(dest => dest.Name, src => src.MapFrom(hp => hp.Profession.Name));

         CreateMap<Data.Models.HabitantFriends, Friend>()
            .ForMember(dest => dest.Id, src => src.MapFrom(hf => hf.Friend.Id))
            .ForMember(dest => dest.Name, src => src.MapFrom(hf => hf.Friend.Name))
            ;

         CreateMap<Data.Models.Habitant, Habitant>()
            .ForMember ( dest => dest.Professions, src => src.MapFrom( s => s.HabitantProfessions))
            .ForMember ( dest => dest.Friends, src => src.MapFrom(s => s.HabitantFriendsHabitant))
            ;
      }
   }
}
