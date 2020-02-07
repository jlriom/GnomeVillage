using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using GnomeVillage.Domain;
using GnomeVillage.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class UpdateHabitantHandler : CommandHandler<UpdateHabitantCommand>
   {
      readonly HabitantUpdateValidator habitantUpdateValidator;
      readonly IHabitantRepository habitantRepository;

      public UpdateHabitantHandler(
         ICommandDispatcher bus, 
         IMapper mapper, 
         ILogger<UpdateHabitantCommand> logger, 
         HabitantUpdateValidator habitantUpdateValidator,
         IHabitantRepository habitantRepository
         ) : base(bus, mapper, logger)
      {
         this.habitantUpdateValidator = habitantUpdateValidator;
         this.habitantRepository = habitantRepository;
      }

      protected override async Task<Result> HandleEx(UpdateHabitantCommand command, CancellationToken cancellationToken = default)
      {
         var habitant = Mapper.Map<Habitant>(command.Data);

         await habitantUpdateValidator.Validate(habitant).ConfigureAwait(false);

         await habitantRepository.UpdateAsync(habitant).ConfigureAwait(false);

         return Result.Ok();
      }
   }
}
