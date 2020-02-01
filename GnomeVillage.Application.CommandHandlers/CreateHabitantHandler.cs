using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class CreateHabitantHandler : CommandHandler<CreateHabitantCommand>
   {
      public CreateHabitantHandler(ICommandDispatcher bus, ILogger<CreateHabitantCommand> logger) : base(bus, logger)
      {
      }

      protected override Task<Result> HandleEx(CreateHabitantCommand command, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
