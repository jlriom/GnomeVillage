using GnomeVillage.Cqrs.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace GnomeVillage.Cqrs.Implementation
{
   public class QueryDispatcher : Bus, IQueryDispatcher
   {
      public QueryDispatcher(IMediator mediator, IUser user) : base(mediator, user)
      {
      }

      public Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) where TResult : class
      {
         return Mediator.Send(query, cancellationToken);
      }
   }
}
