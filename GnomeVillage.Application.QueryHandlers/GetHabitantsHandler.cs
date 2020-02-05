using AutoMapper;
using GnomeVillage.Application.Queries;
using GnomeVillage.Application.Queries.Dto;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using GnomeVillage.ReadModel.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.QueryHandlers
{
   public class GetHabitantsHandler : QueryHandler<GetHabitantsQuery, Paging<HabitantViewModel>>
   {

      private readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;

      public GetHabitantsHandler(IQueryDispatcher bus, IMapper mapper, ILogger<GetHabitantsQuery> logger, IHabitantReadOnlyRepository habitantReadOnlyRepository) : base(bus, mapper, logger)
      {
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
      }

      protected override async Task<Paging<HabitantViewModel>> HandleEx(GetHabitantsQuery query, CancellationToken cancellationToken = default)
      {
         var habitants = await habitantReadOnlyRepository.GetAsync(query.Limit, query.Offset).ConfigureAwait(false);
         return this.Mapper.Map<Paging<HabitantViewModel>>(habitants);
      }
   }
}
