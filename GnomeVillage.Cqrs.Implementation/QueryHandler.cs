using AutoMapper;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Cqrs.Implementation
{
   public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
   {
      private readonly bool logHandler = false;
      protected readonly IBus Bus;
      protected readonly IMapper Mapper;
      protected readonly ILogger<TQuery> Logger;

      protected QueryHandler(IQueryDispatcher bus, IMapper mapper, ILogger<TQuery> logger)
      {
         Bus = bus;
         Mapper = mapper;
         Logger = logger;
      }

      public Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
      {
         if (!logHandler) return HandleEx(request, cancellationToken);

         try
         {
            using (Logger.BeginScope(typeof(TQuery)))
            {
               Logger.LogInformation($"Begin: {typeof(TQuery)}");
               var result = HandleEx(request, cancellationToken);
               Logger.LogInformation($"End: {typeof(TQuery)}");
               return result;
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(ex, $"Error in {typeof(TQuery)}: {ex.Message}");
            throw;
         }
      }

      protected abstract Task<TResult> HandleEx(TQuery query, CancellationToken cancellationToken = default);
   }
}