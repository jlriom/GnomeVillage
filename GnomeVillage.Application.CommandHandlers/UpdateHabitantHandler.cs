using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class UpdateHabitantHandler : CommandHandler<UpdateHabitantCommand>
   {
      public UpdateHabitantHandler(ICommandDispatcher bus, ILogger<UpdateHabitantCommand> logger) : base(bus, logger)
      {
      }

      protected override Task<Result> HandleEx(UpdateHabitantCommand command, CancellationToken cancellationToken = default)
      {
         throw new System.NotImplementedException();
      }
   }
}
