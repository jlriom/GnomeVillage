using AutoMapper;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GnomeVillage.Api.Controllers
{
   [Route("api/habitant")]
   [ApiController]
   public class CommandHabitantController : CommandControllerBase<CommandHabitantController>
   {
      public CommandHabitantController(ILogger<CommandHabitantController> logger, ICommandDispatcher commandDispatcher, IMapper mapper) 
         : base(logger, commandDispatcher, mapper)
      {
      }
   }
}