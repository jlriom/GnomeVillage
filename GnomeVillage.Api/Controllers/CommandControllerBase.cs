using AutoMapper;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GnomeVillage.Api.Controllers
{

   public class CommandControllerBase<T> : ControllerBase where T : ControllerBase
   {
      protected readonly ILogger<T> Logger;
      protected readonly ICommandDispatcher CommandDispatcher;
      protected readonly IMapper Mapper;


      public CommandControllerBase(ILogger<T> logger, ICommandDispatcher commandDispatcher, IMapper mapper)
      {
         Logger = logger;
         CommandDispatcher = commandDispatcher;
         Mapper = mapper;
      }
   }
}