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
   public class CreateHabitantHandler : CommandHandler<CreateHabitantCommand>
   {
      readonly HabitantInsertValidator habitantInsertValidator;
      readonly IHabitantRepository habitantRepository;

      public CreateHabitantHandler(
         ICommandDispatcher bus, 
         IMapper mapper, 
         ILogger<CreateHabitantCommand> logger, 
         HabitantInsertValidator habitantInsertValidator,
         IHabitantRepository habitantRepository) : base(bus, mapper, logger)
      {
         this.habitantInsertValidator = habitantInsertValidator;
         this.habitantRepository = habitantRepository;
      }

      protected override async Task<Result> HandleEx(CreateHabitantCommand command, CancellationToken cancellationToken = default)
      {
         var habitant = Mapper.Map<Habitant>(command.Data);

         await habitantInsertValidator.Validate(habitant).ConfigureAwait(false);

         await habitantRepository.InsertAsync(habitant).ConfigureAwait(false);

         return Result.Ok();
      }
   }
}
