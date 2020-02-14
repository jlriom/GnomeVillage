using System.Collections.Generic;
using System.Threading.Tasks;
using GnomeVillage.Application.Commands;
using GnomeVillage.Application.Commands.Dto;
using GnomeVillage.Application.Queries;
using GnomeVillage.Application.Queries.Dto;
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
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<HabitantViewModel>> GetHabitant(int habitantId, [FromServices] IQueryDispatcher queryDispatcher)
         => Ok(await queryDispatcher.Dispatch(new GetHabitantQuery(habitantId)).ConfigureAwait(false));

      [HttpGet]
      [Route("{limit}/{offset}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<HabitantViewModel>>> GetHabitants(int limit, int offset, [FromServices] IQueryDispatcher queryDispatcher)
         => Ok(await queryDispatcher.Dispatch(new GetHabitantsQuery(limit, offset)).ConfigureAwait(false));


      [HttpPost]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> CreateHabitant([FromBody] Habitant habitant, [FromServices] ICommandDispatcher commandDispatcher)
      {
         await commandDispatcher.Dispatch(new CreateHabitantCommand(habitant)).ConfigureAwait(false);
         return Ok();
      }


      [HttpPut]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [Route("{habitantId}")]
      public async Task<ActionResult> UpdateHabitant(string habitantId, [FromBody] Habitant habitant, [FromServices] ICommandDispatcher commandDispatcher)
      {
         await commandDispatcher.Dispatch(new UpdateHabitantCommand(habitantId, habitant)).ConfigureAwait(false);
         return Ok();
      }

      [HttpDelete]
      [Route("{habitantId}")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> DeleteHabitant(int habitantId, [FromServices] ICommandDispatcher commandDispatcher)
      {
         await commandDispatcher.Dispatch(new DeleteHabitantCommand(habitantId)).ConfigureAwait(false);
         return Ok();
      }

      [HttpPost]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [Route("{habitantId}/friend")]
      public async Task<ActionResult> AddFriendToHabitant(int habitantId, [FromBody]string friendName, [FromServices] ICommandDispatcher commandDispatcher)
      {
         await commandDispatcher.Dispatch(new AddFriendToHabitantCommand(habitantId, friendName)).ConfigureAwait(false);
         return Ok();
      }

      [HttpDelete]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      [Route("{habitantId}/friend")]
      public async Task<ActionResult> DeleteFriendFromHabitant(int habitantId, [FromBody]string friendName, [FromServices] ICommandDispatcher commandDispatcher)
      {
         await commandDispatcher.Dispatch(new DeleteFriendFromHabitantCommand(habitantId, friendName)).ConfigureAwait(false);
         return Ok();
      }
   }
}