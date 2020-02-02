using System.Threading.Tasks;
using GnomeVillage.Application.Commands;
using GnomeVillage.Application.Queries;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GnomeVillage.Api.Controllers
{

   [Produces("application/json")]
   [Route("api/[controller]")]
   [ApiController]
   public class HabitantController : ControllerBase
   {

      [HttpGet]
      [Route("{habitantId}")]
      public async Task<ActionResult> GetHabitant(string habitantId, IQueryDispatcher queryDispatcher)
         => Ok(await queryDispatcher.Dispatch(new GetHabitantQuery(habitantId)));

      [HttpGet]
      [Route("{limit}/{offset}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> GetHabitantsQuery(int limit, int offset, IQueryDispatcher queryDispatcher)
         => Ok(await queryDispatcher.Dispatch(new GetHabitantsQuery(limit, offset)));


      [HttpPost]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> CreateHabitant([FromBody] Application.Commands.Dto.Habitant habitant, ICommandDispatcher commandDispatcher)
         => Ok(await commandDispatcher.Dispatch(new CreateHabitantCommand(habitant)));

      [HttpPut]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [Route("{habitantId}")]
      public async Task<ActionResult> UpdateHabitant(string habitantId, [FromBody] Application.Commands.Dto.Habitant habitant, ICommandDispatcher commandDispatcher)
         => Ok(await commandDispatcher.Dispatch(new UpdateHabitantCommand(habitantId, habitant)));

      [HttpDelete]
      [Route("{habitantId}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> DeleteHabitant(string habitantId, ICommandDispatcher commandDispatcher)
         => Ok(await commandDispatcher.Dispatch(new DeleteHabitantCommand(habitantId)));

      [HttpPost]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [Route("{habitantId}/friend")]
      public async Task<ActionResult> AddFriendToHabitant(string habitantId, [FromBody]string friendName, ICommandDispatcher commandDispatcher)
         => Ok(await commandDispatcher.Dispatch(new AddFriendToHabitantCommand(habitantId, friendName)));

      [HttpDelete]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [Route("{habitantId}/friend")]
      public async Task<ActionResult> DeleteFriendFromHabitant(string habitantId, [FromBody]string friendName, ICommandDispatcher commandDispatcher)
         => Ok(await commandDispatcher.Dispatch(new DeleteFriendFromHabitantCommand(habitantId, friendName)));

   }
}