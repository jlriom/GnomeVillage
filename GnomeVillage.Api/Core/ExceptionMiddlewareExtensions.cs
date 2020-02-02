using GnomeVillage.Application.Common.Exceptions;
using GnomeVillage.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace GnomeVillage.Api.Core
{
   public static class ExceptionMiddlewareExtensions
   {



      //[ProducesResponseType(StatusCodes.Status200OK)]
      //[ProducesResponseType(StatusCodes.Status400BadRequest)]
      //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
      //[ProducesResponseType(StatusCodes.Status404NotFound)]
      ////[ProducesResponseType(StatusCodes.Status500InternalServerError)]


      public static void ConfigureExceptionHandler(this IApplicationBuilder app)
      {
         app.UseExceptionHandler(errorApp =>
         {
            errorApp.Run(async context =>
            {

               context.Response.ContentType = "application/json";
               context.Response.StatusCode = StatusCodes.Status500InternalServerError;

               var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

               if (exceptionHandlerPathFeature?.Error != null)
               {
                  if (exceptionHandlerPathFeature?.Error is AppException || exceptionHandlerPathFeature?.Error is DomainException)
                  {
                     context.Response.StatusCode = StatusCodes.Status400BadRequest;
                  }
                  else if (exceptionHandlerPathFeature?.Error is NotFoundException)
                  {
                     context.Response.StatusCode = StatusCodes.Status404NotFound;
                  }
                  else if (exceptionHandlerPathFeature?.Error is UnauthorizedException)
                  {
                     context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                  }
                  await context.Response.WriteAsync(exceptionHandlerPathFeature?.Error.ToString());
               }
            });
         });
      }
   }
}
