using AutoMapper;
using GnomeVillage.Application.Queries;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using GnomeVillage.ReadModel.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.QueryHandlers
{
   public class GetProfessionsHandler : QueryHandler<GetProfessionsQuery, IEnumerable<string>>
   {
      private readonly IProfessionReadOnlyRepository professionReadOnlyRepository;

      public GetProfessionsHandler(IQueryDispatcher bus, IMapper mapper, ILogger<GetProfessionsQuery> logger, IProfessionReadOnlyRepository professionReadOnlyRepository) : base(bus, mapper, logger)
      {
         this.professionReadOnlyRepository = professionReadOnlyRepository;
      }

      protected override async Task<IEnumerable<string>> HandleEx(GetProfessionsQuery query, CancellationToken cancellationToken = default)
      {
         return this.Mapper.Map<IEnumerable<string>>(await professionReadOnlyRepository.GetAllAsync().ConfigureAwait(false));
      }
   }
}
