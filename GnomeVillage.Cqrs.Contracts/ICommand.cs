using CSharpFunctionalExtensions;
using MediatR;

namespace GnomeVillage.Cqrs.Contracts
{
   public interface ICommand : IRequest<Result>
   {
   }
}
