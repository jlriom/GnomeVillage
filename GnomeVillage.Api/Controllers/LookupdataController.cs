using GnomeVillage.Application.Queries;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnomeVillage.Api.Controllers
{

   [Produces("application/json")]
   [Route("api/[controller]")]
   [ApiController]
   public class LookupdataController : ControllerBase
   {

      [HttpGet]
      [Route("HairColor")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<string>>> GetHairColors([FromServices] IQueryDispatcher queryDispatcher)
         => Ok(await queryDispatcher.Dispatch(new GetHairColorsQuery()));

      [HttpGet]
      [Route("Profession")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<string>>> GetProfessions([FromServices] IQueryDispatcher queryDispatcher)
         => Ok(await queryDispatcher.Dispatch(new GetProfessionsQuery()));


   }
}