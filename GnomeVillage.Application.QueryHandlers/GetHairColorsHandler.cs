using GnomeVillage.Application.Queries;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.QueryHandlers
{
   public class GetHairColorsHandler : QueryHandler<GetHairColorsQuery, IEnumerable<string>>
   {
      public GetHairColorsHandler(IQueryDispatcher bus, ILogger<GetHairColorsQuery> logger) : base(bus, logger)
      {
      }

      protected override Task<IEnumerable<string>> HandleEx(GetHairColorsQuery query, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
