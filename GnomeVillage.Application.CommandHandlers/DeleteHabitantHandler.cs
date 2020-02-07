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
   public class DeleteHabitantHandler : CommandHandler<DeleteHabitantCommand>
   {
      readonly HabitantDeleteValidator habitantDeleteValidator;
      readonly IHabitantRepository habitantRepository;

      public DeleteHabitantHandler(
         ICommandDispatcher bus, 
         IMapper mapper, 
         ILogger<DeleteHabitantCommand> logger, 
         HabitantDeleteValidator habitantDeleteValidator,
         IHabitantRepository habitantRepository
         ) : base(bus, mapper, logger)
      {
         this.habitantDeleteValidator = habitantDeleteValidator;
         this.habitantRepository = habitantRepository;
      }

      protected override async Task<Result> HandleEx(DeleteHabitantCommand command, CancellationToken cancellationToken = default)
      {
         var habitant = new Habitant(new HabitantId(command.HabitantId));

         await habitantDeleteValidator.Validate(habitant).ConfigureAwait(false);

         await habitantRepository.DeleteAsync(habitant).ConfigureAwait(false);

         return Result.Ok();
      }
   }
}
