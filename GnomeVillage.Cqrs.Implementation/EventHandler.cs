using GnomeVillage.Cqrs.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Cqrs.Implementation
{
   public abstract class EventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
   {
      private readonly bool logHandler = false;
      protected readonly IBus Bus;
      protected readonly ILogger<IEvent> Logger;

      protected EventHandler(IBus bus, ILogger<IEvent> logger)
      {
         Bus = bus;
         Logger = logger;
      }

      public Task Handle(TEvent notification, CancellationToken cancellationToken)
      {
         if (!logHandler) return HandleEx(notification, cancellationToken);

         try
         {
            using (Logger.BeginScope(typeof(TEvent)))
            {
               Logger.LogInformation($"Begin: {typeof(TEvent)}");
               var result = HandleEx(notification, cancellationToken);
               Logger.LogInformation($"End: {typeof(TEvent)}");
               return result;
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(ex, $"Error in {typeof(TEvent)}: {ex.Message}");
            throw;
         }
      }

      protected abstract Task HandleEx(TEvent notification, CancellationToken cancellationToken = default);
   }
}
