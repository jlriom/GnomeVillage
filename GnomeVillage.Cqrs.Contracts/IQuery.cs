using MediatR;

namespace GnomeVillage.Cqrs.Contracts
{
   public interface IQuery<out TResult> : IRequest<TResult> where TResult : class
   {
   }
}
