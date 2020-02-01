using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GnomeVillage.Api.Controllers
{

   public class CommandControllerBase<T> : ControllerBase where T : ControllerBase
   {
      protected readonly ILogger<T> Logger;
      protected readonly ICommandDispatcher CommandDispatcher;

      public CommandControllerBase(ILogger<T> logger, ICommandDispatcher commandDispatcher)
      {
         Logger = logger;
         CommandDispatcher = commandDispatcher;
      }
   }
}