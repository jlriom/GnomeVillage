using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class DeleteHabitantHandler : CommandHandler<DeleteHabitantCommand>
   {
      public DeleteHabitantHandler(ICommandDispatcher bus, IMapper mapper, ILogger<DeleteHabitantCommand> logger) : base(bus, mapper, logger)
      {
      }

      protected override Task<Result> HandleEx(DeleteHabitantCommand command, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
