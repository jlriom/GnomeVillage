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
   public class AddFriendToHabitantHandle : CommandHandler<AddFriendToHabitantCommand>
   {
      public AddFriendToHabitantHandle(ICommandDispatcher bus, ILogger<AddFriendToHabitantCommand> logger) : base(bus, logger)
      {
      }

      protected override Task<Result> HandleEx(AddFriendToHabitantCommand command, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
