using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GnomeVillage.Domain.Implementation.Mappings
{
   public class HabitantProfile: Profile
   {
      public HabitantProfile()
      {
         CreateMap<Habitant, Data.Models.Habitant>()
            .ForMember( dest => dest.HairColor, src => src.Ignore())
            .ForMember (dest => dest.Id, src => src.Ignore())
            .ConstructUsing(src => new Data.Models.Habitant
            {
               Age = src.Age,
               HairColorId = src.HairColor.Id,
               HairColor = null,
               Name = src.Name,
               Weight = src.Weight,
               Height = src.Height,
               Thumbnail = src.Thumbnail.ToString(),
               HabitantProfessions = src.Professions.Select(p => new Data.Models.HabitantProfessions
               {
                  HabitantId = src.Id,
                  ProfessionId = p.Id, 
                  Profession = null
               }).ToList()
            })
            ;
      }
   }
}
