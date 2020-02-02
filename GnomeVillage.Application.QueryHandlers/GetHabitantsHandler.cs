﻿using GnomeVillage.Application.Queries;
using GnomeVillage.Application.Queries.Dto;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.QueryHandlers
{
   public class GetHabitantsHandler : QueryHandler<GetHabitantsQuery, Paging<HabitantViewModel>>
   {
      public GetHabitantsHandler(IQueryDispatcher bus, ILogger<GetHabitantsQuery> logger) : base(bus, logger)
      {
      }

      protected override Task<Paging<HabitantViewModel>> HandleEx(GetHabitantsQuery query, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
