using AutoMapper;
using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GnomeVillage.Api.Controllers
{
   [Route("api/habitant")]
   [ApiController]
   public class QueryHabitantController : QueryControllerBase<QueryHabitantController>
   {
      public QueryHabitantController(ILogger<QueryHabitantController> logger, IQueryDispatcher queryDispatcher, IMapper mapper) 
         : base(logger, queryDispatcher, mapper)
      {
      }
   }
}