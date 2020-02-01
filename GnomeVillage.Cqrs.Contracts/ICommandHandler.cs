using CSharpFunctionalExtensions;
using MediatR;

namespace GnomeVillage.Cqrs.Contracts
{
   public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
   {
   }
}
