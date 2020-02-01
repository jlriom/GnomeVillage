using GnomeVillage.Cqrs.Contracts;
using MediatR;

namespace GnomeVillage.Cqrs.Implementation
{
   public class Bus : IBus
   {
      public IUser User { get; }

      protected readonly IMediator Mediator;

      public Bus(IMediator mediator, IUser user)
      {
         Mediator = mediator;
         User = user;
      }

      public void Publish(IEvent @event)
      {
         Mediator.Publish(@event);
      }
   }
}
