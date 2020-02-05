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
   public class GetHairColorsHandler : QueryHandler<GetHairColorsQuery, IEnumerable<string>>
   {
      private readonly IHairColorReadonlyRepository hairColorReadonlyRepository;

      public GetHairColorsHandler(IQueryDispatcher bus, IMapper mapper, ILogger<GetHairColorsQuery> logger, IHairColorReadonlyRepository hairColorReadonlyRepository) : base(bus, mapper, logger)
      {
         this.hairColorReadonlyRepository = hairColorReadonlyRepository;
      }

      protected override async Task<IEnumerable<string>> HandleEx(GetHairColorsQuery query, CancellationToken cancellationToken = default)
      {
         return this.Mapper.Map<IEnumerable<string>>(await hairColorReadonlyRepository.GetAllAsync().ConfigureAwait(false));
      }
   }
}
