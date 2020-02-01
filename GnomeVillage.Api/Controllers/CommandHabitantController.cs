using GnomeVillage.Application.Commands;
using GnomeVillage.Application.Commands.dto;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GnomeVillage.Api.Controllers
{
   [Route("api/habitant")]
   [ApiController]
   public class CommandHabitantController : CommandControllerBase<CommandHabitantController>
   {
      public CommandHabitantController(ILogger<CommandHabitantController> logger, ICommandDispatcher commandDispatcher)
         : base(logger, commandDispatcher)
      {
      }

      [HttpPost]
      public async Task<ActionResult> CreateHabitant([FromBody] Habitant habitant)
         => Ok(await CommandDispatcher.Dispatch(new CreateHabitantCommand(habitant)));

      [HttpPut]
      public async Task<ActionResult> UpdateHabitant([FromBody] Habitant habitant)
         => Ok(await CommandDispatcher.Dispatch(new UpdateHabitantCommand(habitant)));

      [HttpDelete]
      public async Task<ActionResult> DeleteHabitant([FromBody] string habitantId)
         => Ok(await CommandDispatcher.Dispatch(new DeleteHabitantCommand(habitantId)));

      [HttpPost]
      [Route("friend")]
      public async Task<ActionResult> AddFriendToHabitant([FromBody] string habitantId, [FromBody] string friendName)
         => Ok(await CommandDispatcher.Dispatch(new AddFriendToHabitantCommand(habitantId, friendName)));

      [HttpDelete]
      [Route("friend")]
      public async Task<ActionResult> DeleteFriendFromHabitant([FromBody] string habitantId, [FromBody] string friendName)
         => Ok(await CommandDispatcher.Dispatch(new DeleteFriendFromHabitantCommand(habitantId, friendName)));

   }
}