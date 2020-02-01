using MediatR;

namespace GnomeVillage.Cqrs.Contracts
{
   public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
   {
   }
}
