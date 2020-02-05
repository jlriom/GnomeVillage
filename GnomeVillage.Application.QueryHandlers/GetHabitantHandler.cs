using AutoMapper;
using CSharpFunctionalExtensions;
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
   public class GetHabitantHandler : QueryHandler<GetHabitantQuery, HabitantViewModel>
   {
      private readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;

      public GetHabitantHandler(IQueryDispatcher bus, IMapper mapper, ILogger<GetHabitantQuery> logger, IHabitantReadOnlyRepository habitantReadOnlyRepository) : base(bus, mapper, logger)
      {
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
      }

      protected override async Task<HabitantViewModel> HandleEx(GetHabitantQuery query, CancellationToken cancellationToken = default)
      {
         var habitant = await habitantReadOnlyRepository.GetSingleAsync(query.Id);
         if (habitant.HasValue)
            return Mapper.Map<HabitantViewModel> (habitant.Value);
         return null;
      }
   }
}
