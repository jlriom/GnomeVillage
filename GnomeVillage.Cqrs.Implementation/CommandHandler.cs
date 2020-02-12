using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Cqrs.Implementation
{
   public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
   {
      private readonly bool logHandler = true;

      protected readonly IBus Bus;
      protected readonly IMapper Mapper;
      protected readonly ILogger<TCommand> Logger;

      protected CommandHandler(ICommandDispatcher bus, IMapper mapper, ILogger<TCommand> logger)
      {
         Bus = bus;
         Mapper = mapper;
         Logger = logger;
      }

      public Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
      {
         if (!logHandler) return HandleEx(request, cancellationToken);

         try
         {
            using (Logger.BeginScope(typeof(TCommand)))
            {
               Logger.LogInformation($"Begin: {typeof(TCommand)}");
               var result = HandleEx(request, cancellationToken);
               Logger.LogInformation($"End: {typeof(TCommand)}");
               return result;
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(ex, $"Error in {typeof(TCommand)}: {ex.Message}");
            throw;
         }
      }

      protected abstract Task<Result> HandleEx(TCommand command, CancellationToken cancellationToken = default);
   }
}
