using AutoMapper;
using GnomeVillage.Application.Queries.Dto;
using GnomeVillage.ReadModel.Contracts.Models;

namespace GnomeVillage.Application.QueryHandlers.Mappings
{
   public class HabitantViewModelProfile: Profile
   {
      public HabitantViewModelProfile()
      {
         CreateMap<Habitant, HabitantViewModel>();
      }
   }
}
