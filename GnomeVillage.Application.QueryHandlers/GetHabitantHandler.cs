using GnomeVillage.Application.Queries;
using GnomeVillage.Application.Queries.Dto;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.QueryHandlers
{
   public class GetHabitantHandler : QueryHandler<GetHabitantQuery, Habitant>
   {
      public GetHabitantHandler(IQueryDispatcher bus, ILogger<GetHabitantQuery> logger) : base(bus, logger)
      {
      }

      protected override Task<Habitant> HandleEx(GetHabitantQuery query, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
