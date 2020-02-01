using GnomeVillage.Cqrs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GnomeVillage.Api.Controllers
{

   public class QueryControllerBase<T> : ControllerBase where T : ControllerBase
   {
      protected readonly ILogger<T> Logger;
      protected readonly IQueryDispatcher QueryDispatcher;

      public QueryControllerBase(ILogger<T> logger, IQueryDispatcher queryDispatcher)
      {
         Logger = logger;
         QueryDispatcher = queryDispatcher;
      }
   }
}