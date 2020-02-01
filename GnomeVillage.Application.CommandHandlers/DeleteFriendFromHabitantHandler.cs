using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class DeleteFriendFromHabitantHandler : CommandHandler<DeleteFriendFromHabitantCommand>
   {
      public DeleteFriendFromHabitantHandler(ICommandDispatcher bus, ILogger<DeleteFriendFromHabitantCommand> logger) : base(bus, logger)
      {
      }

      protected override Task<Result> HandleEx(DeleteFriendFromHabitantCommand command, CancellationToken cancellationToken = default)
      {
         throw new System.NotImplementedException();
      }
   }
}
