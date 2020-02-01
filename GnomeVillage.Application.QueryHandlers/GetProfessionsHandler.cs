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
   public class GetProfessionsHandler : QueryHandler<GetProfessionsQuery, IEnumerable<string>>
   {
      public GetProfessionsHandler(IQueryDispatcher bus, ILogger<GetProfessionsQuery> logger) : base(bus, logger)
      {
      }

      protected override Task<IEnumerable<string>> HandleEx(GetProfessionsQuery query, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
