﻿using GnomeVillage.Application.Queries.Dto;
using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Queries
{
   public class GetHabitantQuery : IQuery<HabitantViewModel>
   {
      public GetHabitantQuery(string id)
      {
         Id = id;
      }

      public string Id { get; }
   }
}
