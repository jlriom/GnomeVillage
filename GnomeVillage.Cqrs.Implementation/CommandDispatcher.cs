using CSharpFunctionalExtensions;
using GnomeVillage.Cqrs.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Cqrs.Implementation
{
   public class CommandDispatcher : Bus, ICommandDispatcher
   {
      public CommandDispatcher(IMediator mediator, IUser user) : base(mediator, user)
      {
      }

      public Task<Result> Dispatch(ICommand command, CancellationToken cancellationToken = default)
      {
         return Mediator.Send(command, cancellationToken);
      }
   }
}
