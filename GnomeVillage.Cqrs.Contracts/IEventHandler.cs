using System.Threading;
using System.Threading.Tasks;


namespace GnomeVillage.Cqrs.Contracts
{
   public interface IEventHandler
   {
      Task Handle(IEvent @event, CancellationToken cancellationToken = default);
   }
}
